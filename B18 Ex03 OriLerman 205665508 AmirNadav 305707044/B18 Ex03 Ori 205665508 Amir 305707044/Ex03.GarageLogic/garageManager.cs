using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace Ex03.GarageLogic
//{
//    public class garageManager
//    {
//        private VehiclesGarage m_garageDataStructure = new VehiclesGarage();

//        public bool CheckIfVehicleExists(string i_LicenseNumber)
//        {
//            bool isInGarage = false;
//            isInGarage = m_garageDataStructure.DoesVehicleExists(i_LicenseNumber);
//            return isInGarage;
//        }
//        public void AddNewVehicle(VehicleInitialDetails i_detailsForCreatingCar)
//        {
//            Vehicle theVehicleToAdd = Factory.createNewVehicle(ref i_detailsForCreatingCar);
//            m_garageDataStructure.Add(theVehicleToAdd);
//        }
//        public void ChangeVehicleRepairState(string i_LicenseNumber, eRepairState i_VehicleNewRepairState)
//        {
//            Vehicle vehicleToInspect;
//            vehicleToInspect = m_garageDataStructure.GetVehicle(i_LicenseNumber);
//         //   vehicleToInspect.RepairState = i_VehicleNewRepairState;
//            if(vehicleToInspect.RepairState != i_VehicleNewRepairState)
//            {
//                m_garageDataStructure.Remove(vehicleToInspect);
//                vehicleToInspect.RepairState = i_VehicleNewRepairState;
//                m_garageDataStructure.Add(vehicleToInspect);
//            }
//        }
//        public void FillTyrePressure(string io_LicenseNumber)
//        {
//            Vehicle vehicleToWorkOn = m_garageDataStructure.GetVehicle(io_LicenseNumber);
//            vehicleToWorkOn.FillAirToMax();
//        }

//    }
//}
