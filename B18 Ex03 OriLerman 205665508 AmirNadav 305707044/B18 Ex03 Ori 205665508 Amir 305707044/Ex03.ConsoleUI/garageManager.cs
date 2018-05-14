using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    public class GarageManager
    {
        private DataStructure m_garageDataStructure = new DataStructure();

        public bool CheckIfVehicleExists(string i_LicenseNumber)
        {
            bool isInGarage = false;
            isInGarage = m_garageDataStructure.DoesVehicleExists(i_LicenseNumber);
            return isInGarage;
        }
        public void AddNewVehicle(VehicleInitialDetails i_detailsForCreatingCar)
        {
            Vehicle theVehicleToAdd = Factory.createNewVehicle(ref i_detailsForCreatingCar);
            m_garageDataStructure.Add(theVehicleToAdd);
        }

        public void ChangeVehicleRepairState(string i_LicenseNumber, eRepairState i_VehicleNewRepairState)
        {
            Vehicle vehicleToInspect;
            vehicleToInspect = m_garageDataStructure.search(i_LicenseNumber);
            if (vehicleToInspect.RepairState != i_VehicleNewRepairState)
            {
                m_garageDataStructure.Remove(vehicleToInspect);
                vehicleToInspect.RepairState = i_VehicleNewRepairState;
                m_garageDataStructure.Add(vehicleToInspect);
            }
        }
        public void FillTyrePressure(string io_LicenseNumber)
        {
            Vehicle vehicleToWorkOn = m_garageDataStructure.search(io_LicenseNumber);
            vehicleToWorkOn.FillAirToMax();
        }
        public void RefuelVehicle(string io_LicenseNumber, Fuel.eFuelType io_TypeOfFuel, float io_AmountToAdd)
        {
            Vehicle vehicleToRefuel = m_garageDataStructure.search(io_LicenseNumber);
            Fuel engineType = vehicleToRefuel.GetEnergyType as Fuel;
            if (engineType != null)
            {
                engineType.Refuel(io_TypeOfFuel, io_AmountToAdd);
            }
            else
            {
                //exception
                throw new ArgumentException(string.Format("The refueld car: {0} should be only fuel (and Not Electric) ",io_LicenseNumber),io_LicenseNumber);
            }

        }
    }
}
