using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{

    public static class Factory
    {
        public enum eSupportedVehicles { Car, Truck, MotorCycle }
        public enum eSupportedEngines { Electric, Fuel }

        public static Vehicle createNewVehicle(ref VehicleInitialDetails i_RequiermentsForVehicle)
        {
            if (i_RequiermentsForVehicle.m_vehicleUsersChoice == eSupportedVehicles.Car)
            {
                return createCar(i_RequiermentsForVehicle);
            }
            else if (i_RequiermentsForVehicle.m_vehicleUsersChoice == eSupportedVehicles.MotorCycle)
            {
                return createMotorCycle(i_RequiermentsForVehicle);
            }
            else if (i_RequiermentsForVehicle.m_vehicleUsersChoice == eSupportedVehicles.Truck)
            {
                return createTruck(i_RequiermentsForVehicle);
            }
            else
            {
                return null;//not sure maybe throw exception maybe else if
            }
        }

        private static Vehicle createTruck(VehicleInitialDetails i_RequiermentsForVehicle)
        {
            Fuel TruckEngine = new Fuel(Fuel.eFuelType.Soler, i_RequiermentsForVehicle.m_EnergyTypeInfo.m_CurrentAmountEnergy, Truck.k_MaxTruckFuel);
            List<Wheel> TruckWheels = new List<Wheel>();
            foreach (VehicleInitialDetails.wheelsInfo w in i_RequiermentsForVehicle.m_WheelsInfoList)
            {
                TruckWheels.Add(new Wheel(w.m_TyreManufacturer, Truck.k_MaxTruckPsi, w.m_TyrePsi));
            }

            return new Truck(
                i_RequiermentsForVehicle.m_TruckInfo.m_TruckCooled,
                i_RequiermentsForVehicle.m_TruckInfo.m_TrunkVolume,
                TruckEngine,
                i_RequiermentsForVehicle.m_Model, i_RequiermentsForVehicle.m_LicensePlate,
                new OwnerDetails(i_RequiermentsForVehicle.m_ownerInfo.m_OwnerName, i_RequiermentsForVehicle.m_ownerInfo.m_OwnerPhone),
                TruckWheels
                );

        }

        private static Vehicle createMotorCycle(VehicleInitialDetails i_RequiermentsForVehicle)
        {
            List<Wheel> motorcycleWheels = new List<Wheel>();
            foreach (VehicleInitialDetails.wheelsInfo w in i_RequiermentsForVehicle.m_WheelsInfoList)
            {
                motorcycleWheels.Add(new Wheel(w.m_TyreManufacturer, Motorcycle.k_MaxMotorcyclePsi, w.m_TyrePsi));
            }

            EnergyType MotorCycleEnergyType;
            if (i_RequiermentsForVehicle.m_EnergyTypeInfo.engine == eSupportedEngines.Electric)
            {
                MotorCycleEnergyType = new ElectricityEngine(i_RequiermentsForVehicle.m_EnergyTypeInfo.m_CurrentAmountEnergy,
                                                             Motorcycle.k_MaxMotorcycleElectricHours);
            }
            else///fuel
            {
                MotorCycleEnergyType = new Fuel(Fuel.eFuelType.Octan96, i_RequiermentsForVehicle.m_EnergyTypeInfo.m_CurrentAmountEnergy, Motorcycle.k_MaxMotorcycleFuel);
            }

            return new Motorcycle(i_RequiermentsForVehicle.m_MotorCycleInfo.m_licenceType,
                                  i_RequiermentsForVehicle.m_MotorCycleInfo.m_EngineVolume,
                                  MotorCycleEnergyType,
                                  i_RequiermentsForVehicle.m_Model,
                                  i_RequiermentsForVehicle.m_LicensePlate,
                                  new OwnerDetails(i_RequiermentsForVehicle.m_ownerInfo.m_OwnerName, i_RequiermentsForVehicle.m_ownerInfo.m_OwnerPhone),
                                  motorcycleWheels);
        }

        private static Vehicle createCar(VehicleInitialDetails i_RequiermentsForVehicle)
        {

            List<Wheel> carWheels = new List<Wheel>();
            foreach (VehicleInitialDetails.wheelsInfo w in i_RequiermentsForVehicle.m_WheelsInfoList)
            {
                carWheels.Add(new Wheel(w.m_TyreManufacturer, Car.k_MaxCarPsi, w.m_TyrePsi));
            }

            EnergyType carEnergyType;
            if (i_RequiermentsForVehicle.m_EnergyTypeInfo.engine == eSupportedEngines.Electric)
            {
                carEnergyType = new ElectricityEngine(i_RequiermentsForVehicle.m_EnergyTypeInfo.m_CurrentAmountEnergy,
                                                             Car.k_MaxCarElectricHours);
            }
            else///fuel
            {
                carEnergyType = new Fuel(Fuel.eFuelType.Octan98, i_RequiermentsForVehicle.m_EnergyTypeInfo.m_CurrentAmountEnergy, Car.k_MaxCarFuel);
            }

            return new Car(i_RequiermentsForVehicle.m_CarInfo.m_Color,
                           i_RequiermentsForVehicle.m_CarInfo.m_NumberOfDoors,
                           carEnergyType,
                           i_RequiermentsForVehicle.m_Model,
                           i_RequiermentsForVehicle.m_LicensePlate,
                           new OwnerDetails(i_RequiermentsForVehicle.m_ownerInfo.m_OwnerName, i_RequiermentsForVehicle.m_ownerInfo.m_OwnerPhone),
                           carWheels);

        }
    }
}
