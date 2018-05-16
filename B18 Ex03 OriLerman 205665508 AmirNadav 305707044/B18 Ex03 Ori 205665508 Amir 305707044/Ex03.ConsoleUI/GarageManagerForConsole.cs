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
        private const string k_MenuOptions =
@"======================================================================
What would you like to do?
    1. Add a new vehicle to the garage.
    2. Show license numbers of vehicles in the garage.
    3. Change a vehicle repair state.
    4. Fill vehicle wheels with air.
    5. Refuel a gas engined vehicle.
    6. Recharge an electric engined vehicle.
    7. Show full details of a specific vehicle.
    8. Exit garage
======================================================================";
        private const string k_AddNewVehicleMessage = "Vehicle number {0} was added succesfully!";
        private const string k_VehicleExistsMessage = "Vehicle number {0} is now in repair!";
        private const string k_ChangeStateMessage = "Vehicle number {0} repair state was changed successfuly!";
        private const string k_FillAirMessage = "Vehicle number {0} tyres are now filled with air!";
        private const string k_GasTankFullMessage = "Vehicle number {0} gas tank is now full!";
        private const string k_BatteryChargedMessage = "Vehicle number {0} battery is now fully charged!";
        private const string k_PressAnyKeyMessage = "Press any key to continue...";
        private const string k_EnterLicenseNumber = "Please enter a license number: ";


        public enum eUserChoice { AddVehicle = 1, ShowLicenseNumbers, ChangeVehicleState, FillVehicleAir, RefuelVehicle, RechargeVehicle, ShowVehicleFullDetails, Exit }

        //public enum eFiltering { NoFilter, InShop, Fixed, Payed }
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
                    interpretUserChoice(userInput, out m_MenuChoice);
                    executeUserChoice(m_MenuChoice);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Ex03.GarageLogic.ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("someThing Went Wrong mate -> but generally wrong");///needs better text
                }

                Console.WriteLine(k_PressAnyKeyMessage);
                Console.ReadLine();
                Console.Clear();

            }
        }

        private void showGarageMenu()
        {
            Console.WriteLine(k_MenuOptions);
        }
        private void interpretUserChoice(string i_UserChoice, out eUserChoice o_Choice)
        {
            o_Choice = (eUserChoice)Enum.Parse(typeof(eUserChoice), i_UserChoice);
            if(o_Choice < eUserChoice.AddVehicle || o_Choice > eUserChoice.Exit)
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
                userVehicleDetails.m_LicensePlate = licenseNumber;
                AddNewVehicle(userVehicleDetails);
                finishTreatmentMessage.AppendFormat(k_AddNewVehicleMessage, licenseNumber);
            }
            else
            {
                ChangeVehicleRepairState(licenseNumber, eRepairState.InShop);
                finishTreatmentMessage.AppendFormat(k_VehicleExistsMessage, licenseNumber);
            }

            Console.WriteLine(finishTreatmentMessage);
        }
        private void ShowVehiclesLicenseNumbers()
        {
            eRepairState howToFilter;
            howToFilter = readFilterChoice();
            ShowLicenseNumberByFilter(howToFilter);
        }
        private void ChangeVehicleState()
        {
            string licenseNumber;
            eRepairState newRepairState;

            readStateChangeData(out licenseNumber, out newRepairState);
            ChangeVehicleRepairState(licenseNumber, newRepairState);

            Console.WriteLine(k_ChangeStateMessage, licenseNumber);
        }
        private void FillAir()
        {
            string licenseNumber;
            licenseNumber = readLicenseNumber();
            FillTyrePressure(licenseNumber);

            Console.WriteLine(k_FillAirMessage, licenseNumber);


        }
        private void RefuelVehicle()
        {
            string licenseNumber;
            FuelEngine.eFuelType fuelType;
            float litersToAdd;

            readRefulingData(out licenseNumber, out fuelType, out litersToAdd);
            RefuelGasVehicle(licenseNumber, fuelType, litersToAdd);

            Console.WriteLine(k_GasTankFullMessage, licenseNumber);

        }
        private void RechargeVehicle()
        {
            string licenseNumber;
            float minutesToAdd;
            readChargingData(out licenseNumber, out minutesToAdd);
            RechargeElectricVehicle(licenseNumber, minutesToAdd);

            Console.WriteLine(k_BatteryChargedMessage, licenseNumber);
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
            return licenseNumber;
        }
        private void readVehicleDetails(out VehicleInitialDetails o_UserVehicleDetails)
        {
            o_UserVehicleDetails = new VehicleInitialDetails();
            List<VehicleInitialDetails.WheelsListInfo> vehicleWheels = new List<VehicleInitialDetails.WheelsListInfo>();


            Console.Write("\tOwner's Name: ");
            o_UserVehicleDetails.m_ownerInfo.m_OwnerName = Console.ReadLine();
            Console.Write("\tOwner's Phone Number: ");
            o_UserVehicleDetails.m_ownerInfo.m_OwnerPhone = Console.ReadLine();

            Console.Write("\tVehicle Type: (1)Car , (2)Truck, (3)Motorcycle{0}\t", Environment.NewLine);
            o_UserVehicleDetails.m_vehicleUsersChoice = (Factory.eSupportedVehicles)Enum.Parse(typeof(Factory.eSupportedVehicles), Console.ReadLine());

            Console.Write("\tVehicle Model: ");
            o_UserVehicleDetails.m_Model = Console.ReadLine();

            if (o_UserVehicleDetails.m_vehicleUsersChoice == Factory.eSupportedVehicles.Car || o_UserVehicleDetails.m_vehicleUsersChoice == Factory.eSupportedVehicles.MotorCycle)
            {
                Console.Write("\tEngine Type: (1)Electric Engine , (2)Fuel Engine{0}\t", Environment.NewLine);
                o_UserVehicleDetails.m_EnergyTypeInfo.engine = (Factory.eSupportedEngines)Enum.Parse(typeof(Factory.eSupportedEngines), Console.ReadLine());
            }
            else
            {
                o_UserVehicleDetails.m_EnergyTypeInfo.engine = Factory.eSupportedEngines.Fuel;
            }

            if (o_UserVehicleDetails.m_EnergyTypeInfo.engine == Factory.eSupportedEngines.Fuel)
            {
                Console.Write("\tRemaining Fuel (in liters): ");
                o_UserVehicleDetails.m_EnergyTypeInfo.m_CurrentAmountEnergy = float.Parse(Console.ReadLine());
            }
            else
            {
                Console.Write("\tRemaining Battery Time (in hours): ");
                o_UserVehicleDetails.m_EnergyTypeInfo.m_CurrentAmountEnergy = float.Parse(Console.ReadLine());
            }

            switch (o_UserVehicleDetails.m_vehicleUsersChoice)
            {
                case Factory.eSupportedVehicles.Car:
                    Console.Write("\tColor: (1)Gray, (2)Blue, (3)White, (4)Black{0}\t", Environment.NewLine);
                    o_UserVehicleDetails.m_CarInfo.m_Color = (Car.eCarColors)Enum.Parse(typeof(Car.eCarColors), Console.ReadLine());

                    Console.Write("\tNumber of Doors: 2, 3, 4, 5{0}\t", Environment.NewLine);
                    o_UserVehicleDetails.m_CarInfo.m_NumberOfDoors = (Car.eNumberOfDoors)Enum.Parse(typeof(Car.eNumberOfDoors), Console.ReadLine());

                    vehicleWheels.Capacity = Vehicle.k_CarWheels;
                    break;
                case Factory.eSupportedVehicles.MotorCycle:
                    Console.Write("\tLicense Type: (1)A1, (2)A2, (3)A2, (4)B1, (5)B2{0}\t", Environment.NewLine);
                    o_UserVehicleDetails.m_MotorCycleInfo.m_licenceType = (Motorcycle.eLicenseTypes)Enum.Parse(typeof(Motorcycle.eLicenseTypes), Console.ReadLine());
                    Console.Write("\tEngine Volume (in cc): ");
                    o_UserVehicleDetails.m_MotorCycleInfo.m_EngineVolume = int.Parse(Console.ReadLine());

                    vehicleWheels.Capacity = Vehicle.k_MotorcycleWheels;
                    break;
                case Factory.eSupportedVehicles.Truck:
                    Truck.eIsCooled isCooled;
                    Console.Write("\tCooled Trunk? (0)No, (1)Yes{0}\t", Environment.NewLine);
                    isCooled = (Truck.eIsCooled)Enum.Parse(typeof(Truck.eIsCooled), Console.ReadLine());
                    switch (isCooled)
                    {
                        case Truck.eIsCooled.No:
                            o_UserVehicleDetails.m_TruckInfo.m_TruckCooled = false;
                            break;
                        case Truck.eIsCooled.Yes:
                            o_UserVehicleDetails.m_TruckInfo.m_TruckCooled = true;
                            break;
                        default:
                            throw new ArgumentException("Truck trunk must be cooled or not cooled! invalid choice");
                    }

                    Console.Write("\tTrunk Volume: ");
                    o_UserVehicleDetails.m_TruckInfo.m_TrunkVolume = float.Parse(Console.ReadLine());

                    vehicleWheels.Capacity = Vehicle.k_TruckWheels;
                    break;

            }

            Console.Write("\tWheels Manufacturer: ");
            o_UserVehicleDetails.m_WheelInfo.m_TyreManufacturer = Console.ReadLine();
            Console.Write("\tWheel Maximum Psi: ");
            o_UserVehicleDetails.m_WheelInfo.m_TyreMaxPsi = float.Parse(Console.ReadLine());
            for (int i = 1; i <= vehicleWheels.Capacity; i++)
            {
                float currentPressure;
                Console.Write("\tWheel ({0}) Current Psi: ", i);
                currentPressure = float.Parse(Console.ReadLine());
                vehicleWheels.Add(new VehicleInitialDetails.WheelsListInfo(
                                                        o_UserVehicleDetails.m_WheelInfo.m_TyreManufacturer,
                                                        currentPressure,
                                                        o_UserVehicleDetails.m_WheelInfo.m_TyreMaxPsi));
            }

            o_UserVehicleDetails.m_AllWheelsInfo = vehicleWheels;
        }
        private eRepairState readFilterChoice()
        {
            eRepairState requestedState;
            Console.WriteLine("How would you like to filter the results?");
            Console.WriteLine("(0)Show All, (1)In Repair, (2)Fixed, (3)Payed");
            requestedState = (eRepairState)Enum.Parse(typeof(eRepairState), Console.ReadLine());
            return requestedState;
        }
        private void readStateChangeData(out string o_LicenseNumber, out eRepairState o_NewState)
        {
            o_LicenseNumber = readLicenseNumber();
            Console.WriteLine("What is the vehicle new state? (1)In Repair, (2)Fixed, (3)Payed");
            o_NewState = (eRepairState)Enum.Parse(typeof(eRepairState), Console.ReadLine());
            
        }
        private void readRefulingData(out string o_LicenseNumber, out FuelEngine.eFuelType o_FuelType, out float o_LitersToAdd)
        {
            o_LicenseNumber = readLicenseNumber();
            Console.Write("Enter fuel type: ");
            o_FuelType = (FuelEngine.eFuelType)Enum.Parse(typeof(FuelEngine.eFuelType), Console.ReadLine());
            Console.Write("Enter amount to add (in liters): ");
            o_LitersToAdd = float.Parse(Console.ReadLine());

        }
        private void readChargingData(out string o_LicenseNumber, out float o_MinutesToAdd)
        {
            o_LicenseNumber = readLicenseNumber();
            Console.Write("Enter amount to charge (in minutes): ");
            o_MinutesToAdd = float.Parse(Console.ReadLine());

        }



        public bool CheckIfVehicleExists(string i_LicenseNumber)
        {
            bool isInGarage = false;
            isInGarage = m_GarageDataStructure.DoesVehicleExists(i_LicenseNumber);
            return isInGarage;
        }
        public void AddNewVehicle(VehicleInitialDetails i_detailsForCreatingCar)
        {
            Vehicle theVehicleToAdd = Factory.createNewVehicle(ref i_detailsForCreatingCar);
            m_GarageDataStructure.Add(theVehicleToAdd);
        }

        public void ShowLicenseNumberByFilter(eRepairState i_HowToFilter)
        {
            StringBuilder licenseNumbersToPrint = new StringBuilder();
            List<Vehicle> vehiclesList;

            switch (i_HowToFilter)
            {
                case eRepairState.AllStates:
                    if (m_GarageDataStructure.Count > 0)
                    {
                        Dictionary<string, Vehicle> allVehicles = m_GarageDataStructure.GetDictionary();
                        vehiclesList = new List<Vehicle>(allVehicles.Values);
                        licenseNumbersToPrint.AppendFormat("All Vehicles in the Garage:{0}", Environment.NewLine);
                        appendToStringFromList(vehiclesList, ref licenseNumbersToPrint);
                    }
                    break;
                case eRepairState.InShop:
                    vehiclesList = new List<Vehicle>();
                    vehiclesList = m_GarageDataStructure.getInShopList();
                    if (vehiclesList.Count > 0)
                    {
                        licenseNumbersToPrint.AppendFormat("Vehicles that are waiting for repair:{0}", Environment.NewLine);
                        appendToStringFromList(vehiclesList, ref licenseNumbersToPrint);
                    }
                    break;
                case eRepairState.Fixed:
                    vehiclesList = new List<Vehicle>();
                    vehiclesList = m_GarageDataStructure.getFixedList();
                    if (vehiclesList.Count > 0)
                    {
                        licenseNumbersToPrint.AppendFormat("Vehicles that are already fixed:{0}", Environment.NewLine);
                        appendToStringFromList(vehiclesList, ref licenseNumbersToPrint);
                    }
                    break;
                case eRepairState.Payed:
                    vehiclesList = new List<Vehicle>();
                    vehiclesList = m_GarageDataStructure.getPayedList();
                    if (vehiclesList.Count > 0)
                    {
                        licenseNumbersToPrint.AppendFormat("Vehicles that were already payed:{0}", Environment.NewLine);
                        appendToStringFromList(vehiclesList, ref licenseNumbersToPrint);
                    }
                    break;
            }
            if (licenseNumbersToPrint.Length == 0) // we asked for something thats empty
            {
                licenseNumbersToPrint.AppendFormat("There are no license numbers to show at the moment!{0}", Environment.NewLine);
            }

            Console.WriteLine(licenseNumbersToPrint);
        }
        private void appendToStringFromList(List<Vehicle> i_VehiclesList, ref StringBuilder o_licenseNumbers)
        {
            foreach (Vehicle vehicle in i_VehiclesList)
            {
                o_licenseNumbers.AppendFormat("\t{0}{1}", vehicle.LicenseNumber, Environment.NewLine);
            }
        }
        public void ChangeVehicleRepairState(string i_LicenseNumber, eRepairState i_VehicleNewRepairState)
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
        public void FillTyrePressure(string io_LicenseNumber)
        {
            Vehicle vehicleToWorkOn = m_GarageDataStructure.GetVehicle(io_LicenseNumber);
            vehicleToWorkOn.FillAirToMax();
        }
        public void RefuelGasVehicle(string io_LicenseNumber, FuelEngine.eFuelType io_TypeOfFuel, float io_AmountToAdd)
        {
            Vehicle vehicleToRefuel = m_GarageDataStructure.GetVehicle(io_LicenseNumber);
            FuelEngine fuelEngine = vehicleToRefuel.GetEnergySource as FuelEngine;
            if (fuelEngine != null)
            {
                fuelEngine.Refuel(io_TypeOfFuel, io_AmountToAdd);
            }
            else
            {
                //exception
                throw new ArgumentException(string.Format("The refueld car: {0} should be only fuel (and not electric) ", io_LicenseNumber), io_LicenseNumber);
            }

        }
        public void RechargeElectricVehicle(string io_LicenseNumber, float i_MinutesToAdd)
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
                throw new ArgumentException(string.Format("The recharged car: {0} should be only electric (and not fuel) ", io_LicenseNumber), io_LicenseNumber);
            }
        }
        public void ShowAllDataOnVehicle(string io_LicenseNumber)
        {
            Vehicle vehicleToShow = m_GarageDataStructure.GetVehicle(io_LicenseNumber);
            Console.WriteLine(vehicleToShow.ToString());
        }
    }
}
