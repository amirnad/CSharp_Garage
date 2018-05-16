using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eSupportedVehicles { Car = 1, Truck, MotorCycle }
    public enum eSupportedEngines { Electric = 1, Fuel }

    public static class Factory
    {

        public static Vehicle createNewVehicle(ref VehicleInitialDetails io_RequiermentsForVehicle)
        {
            Vehicle vehicleCreated = null;

            if (io_RequiermentsForVehicle.VehicleType == eSupportedVehicles.Car)
            {
                vehicleCreated = createCar(io_RequiermentsForVehicle);
            }
            else if (io_RequiermentsForVehicle.VehicleType == eSupportedVehicles.MotorCycle)
            {
                vehicleCreated = createMotorCycle(io_RequiermentsForVehicle);
            }
            else if (io_RequiermentsForVehicle.VehicleType == eSupportedVehicles.Truck)
            {
                vehicleCreated = createTruck(io_RequiermentsForVehicle);
            }
            else
            {
                throw new FormatException("Unsupported Vehicle Type");
            }


            return vehicleCreated;
        }


        private static Vehicle createTruck(VehicleInitialDetails i_RequiermentsForVehicle)
        {
            List<Wheel> TruckWheels = new List<Wheel>((int)eVehicleWheels.TruckWheels);
            WheelInfo wheelToCreate = i_RequiermentsForVehicle.WheelDetails;
            if (wheelToCreate.MaxTyrePressure > Motorcycle.k_MaxMotorcyclePsi)
            {
                throw new ValueOutOfRangeException(0f, Motorcycle.k_MaxMotorcyclePsi, "wheel.m_TyreMaxPsi");
            }
            for (int i = 0; i < TruckWheels.Capacity; i++)
            {
                //TruckWheels.Add(new Wheel(wheelToCreate.m_TyreManufacturer, wheelToCreate.m_TyreMaxPsi, wheelToCreate.m_TyreCurrentPsi));
                TruckWheels.Add(new Wheel(wheelToCreate));
            }
            FuelEngine truckEngine = new FuelEngine(FuelEngine.eFuelType.Soler, i_RequiermentsForVehicle.EngineType.CurrentEnergy, Truck.k_MaxTruckFuel);
            return new Truck(
                            i_RequiermentsForVehicle.Model,
                            i_RequiermentsForVehicle.LicenseNumber,
                            i_RequiermentsForVehicle.OwnerDetails,
                            TruckWheels,
                            i_RequiermentsForVehicle.TruckDetails,
                            truckEngine);

            //return new Truck(
            //    i_RequiermentsForVehicle.m_TruckInfo.m_TruckCooled,
            //    i_RequiermentsForVehicle.m_TruckInfo.m_TrunkVolume,
            //    truckEngine,
            //    i_RequiermentsForVehicle.m_Model, i_RequiermentsForVehicle.m_LicensePlate,
            //    new OwnerDetails(i_RequiermentsForVehicle.m_ownerInfo.m_OwnerName, i_RequiermentsForVehicle.m_ownerInfo.m_OwnerPhone),
            //    TruckWheels
            //    );

        }

        private static Vehicle createMotorCycle(VehicleInitialDetails i_RequiermentsForVehicle)
        {
            List<Wheel> motorcycleWheels = new List<Wheel>((int)eVehicleWheels.MotorcycleWheels);
            WheelInfo wheelToCreate = i_RequiermentsForVehicle.WheelDetails;
            if (wheelToCreate.MaxTyrePressure > Motorcycle.k_MaxMotorcyclePsi)
            {
                throw new ValueOutOfRangeException(0f, Car.k_MaxCarPsi, "Tyre Max PSI is TOO HIGH!");
            }
            for (int i = 0; i < motorcycleWheels.Capacity; i++)
            {
                //motorcycleWheels.Add(new Wheel(wheelToCreate.m_TyreManufacturer, wheelToCreate.m_TyreMaxPsi, wheelToCreate.m_TyreCurrentPsi));
                motorcycleWheels.Add(new GarageLogic.Wheel(wheelToCreate));
            }

            EnergyType MotorCycleEngine;
            if (i_RequiermentsForVehicle.EngineType.Type == eSupportedEngines.Electric)
            {
                MotorCycleEngine = new ElectricityEngine(
                                                    i_RequiermentsForVehicle.EngineType.CurrentEnergy,
                                                    Motorcycle.k_MaxMotorcycleElectricHours);
            }
            else
            {
                MotorCycleEngine = new FuelEngine(
                                                FuelEngine.eFuelType.Octan96,
                                                i_RequiermentsForVehicle.EngineType.CurrentEnergy,
                                                Motorcycle.k_MaxMotorcycleFuel);
            }
            return new Motorcycle(
                                i_RequiermentsForVehicle.Model,
                                i_RequiermentsForVehicle.LicenseNumber,
                                i_RequiermentsForVehicle.OwnerDetails,
                                motorcycleWheels,
                                i_RequiermentsForVehicle.MotorcycleDetails,
                                MotorCycleEngine);

            //return new Motorcycle(i_RequiermentsForVehicle.m_MotorCycleInfo.m_licenceType,
            //                      i_RequiermentsForVehicle.m_MotorCycleInfo.m_EngineVolume,
            //                      MotorCycleEngine,
            //                      i_RequiermentsForVehicle.m_Model,
            //                      i_RequiermentsForVehicle.m_LicensePlate,
            //                      new OwnerDetails(i_RequiermentsForVehicle.m_ownerInfo.m_OwnerName, i_RequiermentsForVehicle.m_ownerInfo.m_OwnerPhone),
            //                      motorcycleWheels);
        }

        private static Vehicle createCar(VehicleInitialDetails i_RequiermentsForVehicle)
        {

            List<Wheel> carWheels = new List<Wheel>((int)eVehicleWheels.CarWheels);
            WheelInfo wheelToCreate = i_RequiermentsForVehicle.WheelDetails;
            if (wheelToCreate.MaxTyrePressure > Car.k_MaxCarPsi)
            {
                throw new ValueOutOfRangeException(0f, Car.k_MaxCarPsi, "wheel.m_TyreMaxPsi");
            }
            for (int i = 0; i < carWheels.Capacity; i++)
            {
                //carWheels.Add(new Wheel(wheelToCreate.m_TyreManufacturer, wheelToCreate.m_TyreMaxPsi, wheelToCreate.m_TyreCurrentPsi));
                carWheels.Add(new Wheel(wheelToCreate));
            }

            EnergyType carEngine;
            if (i_RequiermentsForVehicle.EngineType.Type == eSupportedEngines.Electric)
            {
                carEngine = new ElectricityEngine(
                                                   i_RequiermentsForVehicle.EngineType.CurrentEnergy,
                                                   Car.k_MaxCarElectricHours);
            }
            else if (i_RequiermentsForVehicle.EngineType.Type == eSupportedEngines.Fuel)
            {
                carEngine = new FuelEngine(
                                            FuelEngine.eFuelType.Octan98,
                                            i_RequiermentsForVehicle.EngineType.CurrentEnergy,
                                            Car.k_MaxCarFuel);
            }
            else
            {
                throw new FormatException("Invalid Engine Type Input!");
            }

            return new Car(
                          i_RequiermentsForVehicle.Model,
                          i_RequiermentsForVehicle.LicenseNumber,
                          i_RequiermentsForVehicle.OwnerDetails,
                          carWheels,
                          i_RequiermentsForVehicle.CarDetails,
                          carEngine);

                          

            //return new Car(i_RequiermentsForVehicle.m_CarInfo.m_Color,
            //               i_RequiermentsForVehicle.m_CarInfo.m_NumberOfDoors,
            //               carEngine,
            //               i_RequiermentsForVehicle.m_Model,
            //               i_RequiermentsForVehicle.m_LicensePlate,
            //               new OwnerDetails(i_RequiermentsForVehicle.m_ownerInfo.m_OwnerName, i_RequiermentsForVehicle.m_ownerInfo.m_OwnerPhone),
            //               carWheels);

        }
    }
}
