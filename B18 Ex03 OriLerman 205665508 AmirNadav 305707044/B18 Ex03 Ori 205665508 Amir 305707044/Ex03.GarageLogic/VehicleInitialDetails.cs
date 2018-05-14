using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public struct VehicleInitialDetails
    {
        public string m_LicensePlate;
        public string m_Model;
        public EnergyTypeInfo m_EnergyTypeInfo;
        public Factory.eSupportedVehicles m_vehicleUsersChoice;
        public TruckInfo m_TruckInfo;
        public CarInfo m_CarInfo;
        public MotorcycleInfo m_MotorCycleInfo;
        public ownerInfo m_ownerInfo;
        public List<wheelsInfo> m_WheelsInfoList;



        public struct TruckInfo
        {
            public bool m_TruckCooled;
            public int m_TrunkVolume;
            
        }
        public struct CarInfo
        {
            public Car.eCarColors m_Color;
            public Car.eNumberOfDoors m_NumberOfDoors;
        }
        public struct MotorcycleInfo
        {
            public Motorcycle.eLicenseTypes m_licenceType;
            public int m_EngineVolume;
        }
        public struct ownerInfo
        {
            public string m_OwnerName;
            public string m_OwnerPhone;
        }
        public struct wheelsInfo
        {
            public string m_TyreManufacturer;
            public float m_TyrePsi;
            public wheelsInfo(string o_TyreManufacturer,float o_TyrePsi)
            {
                m_TyreManufacturer = o_TyreManufacturer;
                m_TyrePsi = o_TyrePsi;
            }
        }
        public struct EnergyTypeInfo
        {
            public float m_CurrentAmountEnergy;//dont knw yet what this is
            public Factory.eSupportedEngines engine;
        }
    }
}
