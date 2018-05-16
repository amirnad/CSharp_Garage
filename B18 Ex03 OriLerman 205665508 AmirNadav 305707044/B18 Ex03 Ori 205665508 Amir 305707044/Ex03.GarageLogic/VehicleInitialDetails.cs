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
        public WheelInfo m_WheelInfo;
        public List<WheelsListInfo> m_AllWheelsInfo;



        public struct TruckInfo
        {
            public bool m_TruckCooled;
            public float m_TrunkVolume;
            
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
        public struct WheelInfo
        {
            public string m_TyreManufacturer;
            public float m_TyreMaxPsi;
            public WheelInfo(string i_Manufacturer, float i_MaximumPsi)
            {
                m_TyreManufacturer = i_Manufacturer;
                m_TyreMaxPsi = i_MaximumPsi;
            }
        }

        public struct WheelsListInfo
        {
            public string m_TyreManufacturer;
            public float m_TyrePsi;
            public float m_TyreMaxPsi;
            public WheelsListInfo(string i_TyreManufacturer,float i_TyrePsi, float i_TyreMaxPsi)
            {
                m_TyreManufacturer = i_TyreManufacturer;
                m_TyrePsi = i_TyrePsi;
                m_TyreMaxPsi = i_TyreMaxPsi;
            }
        }
        public struct EnergyTypeInfo
        {
            public float m_CurrentAmountEnergy;//dont knw yet what this is
            public Factory.eSupportedEngines engine;
        }
    }
}
