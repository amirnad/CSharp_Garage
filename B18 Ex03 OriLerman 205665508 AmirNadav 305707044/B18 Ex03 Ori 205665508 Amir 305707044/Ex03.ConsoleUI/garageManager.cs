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
        public enum eFiltering { NoFilter, InShop, Fixed, Payed }
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
        public string GetLicenseNumberList(eFiltering i_HowToFilter)
        {
            StringBuilder returnedString = new StringBuilder();
            switch (i_HowToFilter)
            {
                case eFiltering.NoFilter:

                    returnedString.AppendFormat("All Vehicles in the Garage:{0}", Environment.NewLine);
                    returnedString.AppendFormat("\t{0}", m_garageDataStructure.GetListOfLicenseNumbers(eRepairState.AllStates));
                    break;
                case eFiltering.InShop:
                    returnedString.AppendFormat("Vehicles that are waiting for repair:{0}", Environment.NewLine);
                    returnedString.AppendFormat("\t{0}", m_garageDataStructure.GetListOfLicenseNumbers(eRepairState.InShop));
                    break;
                case eFiltering.Fixed:
                    returnedString.AppendFormat("Vehicles that are already fixed:{0}", Environment.NewLine);
                    returnedString.AppendFormat("\t{0}", m_garageDataStructure.GetListOfLicenseNumbers(eRepairState.Fixed));
                    break;
                case eFiltering.Payed:
                    returnedString.AppendFormat("Vehicles that are already payed:{0}", Environment.NewLine);
                    returnedString.AppendFormat("\t{0}", m_garageDataStructure.GetListOfLicenseNumbers(eRepairState.Payed));
                    break;


            }

            return returnedString.ToString();
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
        public void RefuelGasVehicle(string io_LicenseNumber, Fuel.eFuelType io_TypeOfFuel, float io_AmountToAdd)
        {
            Vehicle vehicleToRefuel = m_garageDataStructure.search(io_LicenseNumber);
            Fuel fuelEngine = vehicleToRefuel.GetEnergySource as Fuel;
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
            Vehicle vehicleToRecharge = m_garageDataStructure.search(io_LicenseNumber);
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
        public string GetAllDataOnVehicle(string io_LicenseNumber)
        {
            Vehicle vehicleToShow = m_garageDataStructure.search(io_LicenseNumber);
            return vehicleToShow.ToString();
        }
    }
}
