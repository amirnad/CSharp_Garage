using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageManagerForConsole
    {
        private const string k_WelcomeMessage = "Hello and welcome to our garage!";
        private const string k_Border = "=============================================================================";
        private const string k_MenuOptions =
@"What would you like to do?
    1. Add a new vehicle to the garage.
    2. Show license numbers of vehicles in the garage.
    3. Change a vehicle repair state.
    4. Fill vehicle wheels with air.
    5. Refuel a gas engined vehicle.
    6. Recharge an electric engined vehicle.
    7. Show full details of a specific vehicle.
    8. Exit garage";

        private const string k_AddNewVehicleMessage = "Vehicle number {0} was added succesfully!";
        private const string k_VehicleExistsMessage = "Vehicle number {0} is now in repair!";
        private const string k_ChangeStateMessage = "Vehicle number {0} repair state was changed successfuly!";
        private const string k_FillAirMessage = "Vehicle number {0} - tyres are now filled with air!";
        private const string k_GasTankFullMessage = "Vehicle number {0} - gas tank is now full!";
        private const string k_BatteryChargedMessage = "Vehicle number {0} - battery is now fully charged!";
        private const string k_PressAnyKeyMessage = "Press any key to continue...";
        private const string k_EnterLicenseNumber = "Please enter a license number: ";

        public enum eUserChoice
        {
            AddVehicle = 1,
            ShowLicenseNumbers,
            ChangeVehicleState,
            FillVehicleAir,
            RefuelVehicle,
            RechargeVehicle,
            ShowVehicleFullDetails,
            Exit
        }

        private static bool s_LeaveGarage = false;
        private VehiclesGarage m_GarageDataStructure = new VehiclesGarage();
        private eUserChoice m_MenuChoice;

        public void RunGarage()
        {
            string userInput = string.Empty;
            while (!s_LeaveGarage)
            {
                try
                {
                    showGarageMenu();
                    userInput = Console.ReadLine();
                    Console.WriteLine(k_Border);
                    interpretUserChoice(userInput, out m_MenuChoice);
                    executeUserChoice(m_MenuChoice);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(k_Border);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(k_Border);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(k_Border);
                }

                if (!s_LeaveGarage)
                {
                    Console.WriteLine(k_PressAnyKeyMessage);
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        private void showGarageMenu()
        {
            Console.WriteLine(k_WelcomeMessage);
            Console.WriteLine(k_Border);
            Console.WriteLine(k_MenuOptions);
            Console.WriteLine(k_Border);
        }

        private void interpretUserChoice(string i_UserChoice, out eUserChoice o_Choice)
        {
            o_Choice = (eUserChoice)Enum.Parse(typeof(eUserChoice), i_UserChoice);
            if (o_Choice < eUserChoice.AddVehicle || o_Choice > eUserChoice.Exit)
            {
                throw new ArgumentException("Invalid input to menu!");
            }
        }

        private void executeUserChoice(eUserChoice i_UserChoice)
        {
            switch (i_UserChoice)
            {
                case eUserChoice.AddVehicle:
                    AddVehicleToGarage();
                    break;
                case eUserChoice.ShowLicenseNumbers:
                    ShowVehiclesLicenseNumbers();
                    break;
                case eUserChoice.ChangeVehicleState:
                    ChangeVehicleState();
                    break;
                case eUserChoice.FillVehicleAir:
                    FillAir();
                    break;
                case eUserChoice.RefuelVehicle:
                    RefuelVehicle();
                    break;
                case eUserChoice.RechargeVehicle:
                    RechargeVehicle();
                    break;
                case eUserChoice.ShowVehicleFullDetails:
                    ShowVehicleFullDetails();
                    break;
                case eUserChoice.Exit:
                    s_LeaveGarage = true;
                    break;
            }
        }

        private void AddVehicleToGarage()
        {
            string licenseNumber = string.Empty;
            VehicleInitialDetails userVehicleDetails;
            StringBuilder finishTreatmentMessage = new StringBuilder();

            licenseNumber = readLicenseNumber();

            if (!CheckIfVehicleExists(licenseNumber))
            {
                Console.WriteLine("Vehicle number {0} doesn't exist in the system. Please enter the following details:", licenseNumber);
                readVehicleDetails(out userVehicleDetails);
                userVehicleDetails.LicenseNumber = licenseNumber;
                AddNewVehicle(userVehicleDetails);
                finishTreatmentMessage.AppendFormat(k_AddNewVehicleMessage, licenseNumber);
            }
            else
            {
                ChangeVehicleRepairState(licenseNumber, eRepairState.InShop);
                finishTreatmentMessage.AppendFormat(k_VehicleExistsMessage, licenseNumber);
            }

            Console.WriteLine(k_Border);
            Console.WriteLine(finishTreatmentMessage);
        }

        private void ShowVehiclesLicenseNumbers()
        {
            eRepairState howToFilter;
            howToFilter = readFilterChoice();
            Console.WriteLine(k_Border);
            ShowLicenseNumberByFilter(howToFilter);
        }

        private void ChangeVehicleState()
        {
            string licenseNumber;
            eRepairState newRepairState;

            readStateChangeData(out licenseNumber, out newRepairState);
            ChangeVehicleRepairState(licenseNumber, newRepairState);

            Console.WriteLine(k_ChangeStateMessage, licenseNumber);
            Console.WriteLine(k_Border);
        }

        private void FillAir()
        {
            string licenseNumber;
            licenseNumber = readLicenseNumber();
            FillTyrePressure(licenseNumber);

            Console.WriteLine(k_FillAirMessage, licenseNumber);
            Console.WriteLine(k_Border);
        }

        private void RefuelVehicle()
        {
            string licenseNumber;
            FuelEngine.eFuelType fuelType;
            float litersToAdd;

            readRefulingData(out licenseNumber, out fuelType, out litersToAdd);
            RefuelGasVehicle(licenseNumber, fuelType, litersToAdd);

            Console.WriteLine(k_GasTankFullMessage, licenseNumber);
            Console.WriteLine(k_Border);
        }

        private void RechargeVehicle()
        {
            string licenseNumber;
            float minutesToAdd;
            readChargingData(out licenseNumber, out minutesToAdd);
            RechargeElectricVehicle(licenseNumber, minutesToAdd);

            Console.WriteLine(k_BatteryChargedMessage, licenseNumber);
            Console.WriteLine(k_Border);
        }

        private void ShowVehicleFullDetails()
        {
            string licenseNumber;
            licenseNumber = readLicenseNumber();
            ShowAllDataOnVehicle(licenseNumber);
        }

        private string readLicenseNumber()
        {
            string licenseNumber;
            Console.Write(k_EnterLicenseNumber);
            licenseNumber = Console.ReadLine();
            if (licenseNumber.Length == 0)
            {
                throw new FormatException("License Number mus be filled!");
            }

            return licenseNumber;
        }

        private void readVehicleDetails(out VehicleInitialDetails i_UserVehicleDetails)
        {
            i_UserVehicleDetails = new VehicleInitialDetails();
            OwnerDetails vehicleOwner;
            eSupportedVehicles vehicleType;
            string vehicleModel;
            EnergyTypeInfo engineType;
            CarInfo carInfo;
            MotorcycleInfo motorcycleInfo;
            TruckInfo truckInfo;
            WheelInfo wheelInfo;

            vehicleOwner = readOwnerDetails();
            vehicleType = readVehicleType();
            vehicleModel = readVehicleModel();
            engineType = readEngineInfo(vehicleType);
            switch (vehicleType)
            {
                case eSupportedVehicles.Car:
                    carInfo = readCar();
                    i_UserVehicleDetails.CarDetails = carInfo;
                    break;
                case eSupportedVehicles.MotorCycle:
                    motorcycleInfo = readMotorcycle();
                    i_UserVehicleDetails.MotorcycleDetails = motorcycleInfo;
                    break;
                case eSupportedVehicles.Truck:
                    truckInfo = readTruck();
                    i_UserVehicleDetails.TruckDetails = truckInfo;
                    break;
            }

            wheelInfo = readWheel();

            i_UserVehicleDetails.OwnerDetails = vehicleOwner;
            i_UserVehicleDetails.VehicleType = vehicleType;
            i_UserVehicleDetails.Model = vehicleModel;
            i_UserVehicleDetails.EngineType = engineType;
            i_UserVehicleDetails.WheelDetails = wheelInfo;
        }

        private OwnerDetails readOwnerDetails()
        {
            OwnerDetails vehicleOwner;
            string ownerName;
            string ownerPhoneNumber;

            Console.Write("\tOwner's Name: ");
            ownerName = Console.ReadLine();
            Console.Write("\tOwner's Phone Number: ");
            ownerPhoneNumber = Console.ReadLine();

            if (ownerName.Length == 0 || ownerPhoneNumber.Length == 0)
            {
                throw new FormatException("Owner's Name and Phone must be filled!");
            }

            vehicleOwner = new OwnerDetails(ownerName, ownerPhoneNumber);
            return vehicleOwner;
        }

        private eSupportedVehicles readVehicleType()
        {
            eSupportedVehicles vehicleType;

            Console.Write("\tVehicle Type: (1)Car , (2)Truck, (3)Motorcycle{0}\t", Environment.NewLine);
            vehicleType = (eSupportedVehicles)Enum.Parse(typeof(eSupportedVehicles), Console.ReadLine());
            if (!Enum.IsDefined(typeof(eSupportedVehicles), vehicleType))
            {
                throw new ArgumentException("Undefined Vehicle Type");
            }

            return vehicleType;
        }

        private string readVehicleModel()
        {
            string model;

            Console.Write("\tVehicle Model: ");
            model = Console.ReadLine();
            if (model.Length == 0)
            {
                throw new FormatException("Vehicle Manufacturer must be filled!");
            }

            return model;
        }

        private EnergyTypeInfo readEngineInfo(eSupportedVehicles i_VehicleType)
        {
            EnergyTypeInfo engine;
            eSupportedEngines engineType = eSupportedEngines.Fuel;    // just a default value -- > always being checked!
            float remainingEnergy = 0;  // just default value

            switch (i_VehicleType)
            {
                case eSupportedVehicles.Car:
                case eSupportedVehicles.MotorCycle:
                    Console.Write("\tEngine Type: (1)Electric Engine , (2)Fuel Engine{0}\t", Environment.NewLine);
                    engineType = (eSupportedEngines)Enum.Parse(typeof(eSupportedEngines), Console.ReadLine());
                    break;
                case eSupportedVehicles.Truck:
                    engineType = eSupportedEngines.Fuel;
                    break;
            }

            if (!Enum.IsDefined(typeof(eSupportedEngines), engineType))
            {
                throw new ArgumentException("Undefined Type of Engine");
            }

            switch (engineType)
            {
                case eSupportedEngines.Fuel:
                    Console.Write("\tRemaining Fuel (in liters): ");
                    remainingEnergy = float.Parse(Console.ReadLine());
                    break;
                case eSupportedEngines.Electric:
                    Console.Write("\tRemaining Battery Time (in hours): ");
                    remainingEnergy = float.Parse(Console.ReadLine());
                    break;
            }

            checkValidityOfRemainingEnergy(i_VehicleType, engineType, remainingEnergy);

            engine = new EnergyTypeInfo(remainingEnergy, engineType);
            return engine;
        }

        private void checkValidityOfRemainingEnergy(eSupportedVehicles i_VehicleType, eSupportedEngines i_EngineType, float i_RemainingEnergy)
        {
            switch (i_VehicleType)
            {
                case eSupportedVehicles.Car:
                    if (i_EngineType == eSupportedEngines.Fuel && i_RemainingEnergy > Car.k_MaxCarFuel)
                    {
                        throw new ValueOutOfRangeException(0f, Car.k_MaxCarFuel, "FuelEngine.m_CurrentFuelAmount");
                    }
                    else if (i_EngineType == eSupportedEngines.Electric && i_RemainingEnergy > Car.k_MaxCarElectricHours)
                    {
                        throw new ValueOutOfRangeException(0f, Car.k_MaxCarElectricHours, "ElectricityEngine.m_CurrentBatteryHoursLeft");
                    }

                    break;
                case eSupportedVehicles.MotorCycle:
                    if (i_EngineType == eSupportedEngines.Fuel && i_RemainingEnergy > Motorcycle.k_MaxMotorcycleFuel)
                    {
                        throw new ValueOutOfRangeException(0f, Motorcycle.k_MaxMotorcycleFuel, "FuelEngine.m_CurrentFuelAmount");
                    }
                    else if (i_EngineType == eSupportedEngines.Electric && i_RemainingEnergy > Motorcycle.k_MaxMotorcycleElectricHours)
                    {
                        throw new ValueOutOfRangeException(0f, Motorcycle.k_MaxMotorcycleElectricHours, "ElectricityEngine.m_CurrentBatteryHoursLeft");
                    }

                    break;
                case eSupportedVehicles.Truck:
                    if (i_RemainingEnergy > Truck.k_MaxTruckFuel)
                    {
                        throw new ValueOutOfRangeException(0f, Truck.k_MaxTruckFuel, "FuelEngine.m_CurrentFuelAmount");
                    }

                    break;
            }
        }

        private CarInfo readCar()
        {
            CarInfo returnedCar;
            Car.eCarColors carColor;
            Car.eNumberOfDoors numberOfDoors;

            Console.Write("\tColor: (1)Gray, (2)Blue, (3)White, (4)Black{0}\t", Environment.NewLine);
            carColor = (Car.eCarColors)Enum.Parse(typeof(Car.eCarColors), Console.ReadLine());
            if (!Enum.IsDefined(typeof(Car.eCarColors), carColor))
            {
                throw new ArgumentException("Undefined Car Color");
            }

            Console.Write("\tNumber of Doors: 2, 3, 4, 5{0}\t", Environment.NewLine);
            numberOfDoors = (Car.eNumberOfDoors)Enum.Parse(typeof(Car.eNumberOfDoors), Console.ReadLine());
            if (!Enum.IsDefined(typeof(Car.eNumberOfDoors), numberOfDoors))
            {
                throw new ArgumentException("Undefined Number of Car Doors");
            }

            returnedCar = new CarInfo(carColor, numberOfDoors);

            return returnedCar;
        }

        private MotorcycleInfo readMotorcycle()
        {
            MotorcycleInfo returnedMotorcycle;
            Motorcycle.eLicenseTypes licenseType;
            int engineCC;

            Console.Write("\tLicense Type: (1)A1, (2)A2, (3)A2, (4)B1, (5)B2{0}\t", Environment.NewLine);
            licenseType = (Motorcycle.eLicenseTypes)Enum.Parse(typeof(Motorcycle.eLicenseTypes), Console.ReadLine());
            if (!Enum.IsDefined(typeof(Motorcycle.eLicenseTypes), licenseType))
            {
                throw new ArgumentException("Undefined Motorcycle License");
            }

            Console.Write("\tEngine Volume (in cc): ");
            engineCC = int.Parse(Console.ReadLine());

            returnedMotorcycle = new MotorcycleInfo(licenseType, engineCC);
            return returnedMotorcycle;
        }

        private TruckInfo readTruck()
        {
            TruckInfo returnedTruck;
            Truck.eIsCooled coolingOptions;
            bool isCooled = false;      // only default
            float trunkCapacity;

            Console.Write("\tCooled Trunk? (0)No, (1)Yes{0}\t", Environment.NewLine);
            coolingOptions = (Truck.eIsCooled)Enum.Parse(typeof(Truck.eIsCooled), Console.ReadLine());
            switch (coolingOptions)
            {
                case Truck.eIsCooled.No:
                    isCooled = false;
                    break;
                case Truck.eIsCooled.Yes:
                    isCooled = true;
                    break;
                default:
                    throw new ArgumentException("Truck trunk must be cooled or not cooled! invalid choice");
            }

            Console.Write("\tTrunk Volume: ");
            trunkCapacity = float.Parse(Console.ReadLine());

            returnedTruck = new TruckInfo(isCooled, trunkCapacity);
            return returnedTruck;
        }

        private WheelInfo readWheel()
        {
            WheelInfo returnedWheel;
            string wheelManufacturer = string.Empty;
            float wheelMaximumPsi;
            float wheelCurrentPsi;

            Console.Write("\tWheels Manufacturer: ");
            wheelManufacturer = Console.ReadLine();
            if (wheelManufacturer.Length == 0)
            {
                throw new FormatException("Tyre Manufacturer must be filled!");
            }

            Console.Write("\tWheel Maximum Psi: ");
            wheelMaximumPsi = float.Parse(Console.ReadLine());
            Console.Write("\tWheel Current Psi: ");
            wheelCurrentPsi = float.Parse(Console.ReadLine());

            returnedWheel = new WheelInfo(wheelManufacturer, wheelMaximumPsi, wheelCurrentPsi);
            return returnedWheel;
        }

        private eRepairState readFilterChoice()
        {
            eRepairState requestedState;
            Console.WriteLine("How would you like to filter the results?");
            Console.WriteLine("(0)Show All, (1)In Repair, (2)Fixed, (3)Payed");
            requestedState = (eRepairState)Enum.Parse(typeof(eRepairState), Console.ReadLine());
            if (!Enum.IsDefined(typeof(eRepairState), requestedState))
            {
                throw new ArgumentException("Choose a Valid Filtering Option");
            }

            return requestedState;
        }

        private void readStateChangeData(out string o_LicenseNumber, out eRepairState o_NewState)
        {
            o_LicenseNumber = readLicenseNumber();
            Console.WriteLine("What is the vehicle new state? (1)In Repair, (2)Fixed, (3)Payed");
            o_NewState = (eRepairState)Enum.Parse(typeof(eRepairState), Console.ReadLine());
            if (!Enum.IsDefined(typeof(eRepairState), o_NewState))
            {
                throw new ArgumentException("Choose a Valid New Repair State");
            }
        }

        private void readRefulingData(out string o_LicenseNumber, out FuelEngine.eFuelType o_FuelType, out float o_LitersToAdd)
        {
            o_LicenseNumber = readLicenseNumber();
            Console.Write("Enter fuel type: (1)Octan 95, (2)Octan 96, (3)Octan 98, (4)Soler ");
            o_FuelType = (FuelEngine.eFuelType)Enum.Parse(typeof(FuelEngine.eFuelType), Console.ReadLine());
            if (!Enum.IsDefined(typeof(FuelEngine.eFuelType), o_FuelType))
            {
                throw new ArgumentException("Choose a Valid Type of Fuel");
            }

            Console.Write("Enter amount to add (in liters): ");
            o_LitersToAdd = float.Parse(Console.ReadLine());
        }

        private void readChargingData(out string o_LicenseNumber, out float o_MinutesToAdd)
        {
            o_LicenseNumber = readLicenseNumber();
            Console.Write("Enter amount to charge (in minutes): ");
            o_MinutesToAdd = float.Parse(Console.ReadLine());
        }

        private bool CheckIfVehicleExists(string i_LicenseNumber)
        {
            bool isInGarage = false;
            isInGarage = m_GarageDataStructure.DoesVehicleExists(i_LicenseNumber);
            return isInGarage;
        }

        private void AddNewVehicle(VehicleInitialDetails i_detailsForCreatingCar)
        {
            Vehicle theVehicleToAdd = VehicleFactory.createNewVehicle(i_detailsForCreatingCar);
            m_GarageDataStructure.Add(theVehicleToAdd);
        }

        private void ShowLicenseNumberByFilter(eRepairState i_HowToFilter)
        {
            StringBuilder licenseNumbersToPrint = new StringBuilder();
            List<Vehicle> vehiclesList;

            switch (i_HowToFilter)
            {
                case eRepairState.AllStates:
                    if (m_GarageDataStructure.Count > 0)
                    {
                        Dictionary<string, Vehicle> allVehicles = m_GarageDataStructure.GetWholeGarage();
                        vehiclesList = new List<Vehicle>(allVehicles.Values);
                        licenseNumbersToPrint.AppendFormat("All Vehicles in the Garage:{0}", Environment.NewLine);
                        appendToStringFromList(vehiclesList, ref licenseNumbersToPrint);
                    }

                    break;
                case eRepairState.InShop:
                    vehiclesList = new List<Vehicle>();
                    vehiclesList = m_GarageDataStructure.GetInShopList();
                    if (vehiclesList.Count > 0)
                    {
                        licenseNumbersToPrint.AppendFormat("Vehicles that are waiting for repair:{0}", Environment.NewLine);
                        appendToStringFromList(vehiclesList, ref licenseNumbersToPrint);
                    }

                    break;
                case eRepairState.Fixed:
                    vehiclesList = new List<Vehicle>();
                    vehiclesList = m_GarageDataStructure.GetFixedList();
                    if (vehiclesList.Count > 0)
                    {
                        licenseNumbersToPrint.AppendFormat("Vehicles that are already fixed:{0}", Environment.NewLine);
                        appendToStringFromList(vehiclesList, ref licenseNumbersToPrint);
                    }

                    break;
                case eRepairState.Payed:
                    vehiclesList = new List<Vehicle>();
                    vehiclesList = m_GarageDataStructure.GetPayedList();
                    if (vehiclesList.Count > 0)
                    {
                        licenseNumbersToPrint.AppendFormat("Vehicles that were already payed:{0}", Environment.NewLine);
                        appendToStringFromList(vehiclesList, ref licenseNumbersToPrint);
                    }

                    break;
            }

            if (licenseNumbersToPrint.Length == 0)
            {
                licenseNumbersToPrint.AppendFormat("There are no license numbers to show at the moment!{0}", Environment.NewLine);
            }

            licenseNumbersToPrint.AppendLine(k_Border);
            Console.WriteLine(licenseNumbersToPrint);
        }

        private void appendToStringFromList(List<Vehicle> i_VehiclesList, ref StringBuilder o_licenseNumbers)
        {
            foreach (Vehicle vehicle in i_VehiclesList)
            {
                o_licenseNumbers.AppendFormat("\t{0}{1}", vehicle.LicenseNumber, Environment.NewLine);
            }
        }

        private void ChangeVehicleRepairState(string i_LicenseNumber, eRepairState i_VehicleNewRepairState)
        {
            Vehicle vehicleToInspect;
            vehicleToInspect = m_GarageDataStructure.GetVehicle(i_LicenseNumber);
            if (vehicleToInspect.RepairState != i_VehicleNewRepairState)
            {
                m_GarageDataStructure.Remove(vehicleToInspect);
                vehicleToInspect.RepairState = i_VehicleNewRepairState;
                m_GarageDataStructure.Add(vehicleToInspect);
            }
        }

        private void FillTyrePressure(string io_LicenseNumber)
        {
            Vehicle vehicleToWorkOn = m_GarageDataStructure.GetVehicle(io_LicenseNumber);
            vehicleToWorkOn.FillAirToMax();
        }

        private void RefuelGasVehicle(string io_LicenseNumber, FuelEngine.eFuelType io_TypeOfFuel, float io_AmountToAdd)
        {
            Vehicle vehicleToRefuel = m_GarageDataStructure.GetVehicle(io_LicenseNumber);
            FuelEngine fuelEngine = vehicleToRefuel.GetEnergySource as FuelEngine;
            if (fuelEngine != null)
            {
                fuelEngine.Refuel(io_TypeOfFuel, io_AmountToAdd);
            }
            else
            {
                throw new ArgumentException(string.Format("The refueld car {0} is an Electric Vehicle, try to Recharge instead!", io_LicenseNumber));
            }
        }

        private void RechargeElectricVehicle(string io_LicenseNumber, float i_MinutesToAdd)
        {
            const int k_MinutesInHour = 60;
            Vehicle vehicleToRecharge = m_GarageDataStructure.GetVehicle(io_LicenseNumber);
            ElectricityEngine electricEngine = vehicleToRecharge.GetEnergySource as ElectricityEngine;
            if (electricEngine != null)
            {
                float hoursToAdd = i_MinutesToAdd / k_MinutesInHour;
                electricEngine.ReCharge(hoursToAdd);
            }
            else
            {
                throw new ArgumentException(string.Format("The recharged car {0} is powered by gas. Try to refuel instead!{1}", io_LicenseNumber));
            }
        }

        private void ShowAllDataOnVehicle(string io_LicenseNumber)
        {
            Vehicle vehicleToShow = m_GarageDataStructure.GetVehicle(io_LicenseNumber);
            Console.WriteLine(k_Border);
            Console.WriteLine(vehicleToShow.ToString());
            Console.WriteLine(k_Border);
        }
    }
}
