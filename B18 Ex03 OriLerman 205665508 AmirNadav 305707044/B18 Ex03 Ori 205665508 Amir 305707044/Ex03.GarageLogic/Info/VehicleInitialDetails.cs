using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public struct VehicleInitialDetails
    {
        private string m_LicensePlate;
        private OwnerDetails m_OwnerDetails;
        private eSupportedVehicles m_vehicleUsersChoice;
        private string m_Model;
        private EnergyTypeInfo m_EnergyTypeInfo;

        private TruckInfo m_TruckInfo;
        private CarInfo m_CarInfo;
        private MotorcycleInfo m_MotorCycleInfo;
        private WheelInfo m_WheelInfo;
        //public List<WheelsListInfo> m_AllWheelsInfo;

        public VehicleInitialDetails(
                                    string i_License,
                                    OwnerDetails i_Owner,
                                    eSupportedVehicles i_VehicleType,
                                    string i_Model,
                                    EnergyTypeInfo i_EngineType,
                                    TruckInfo i_Truck,
                                    CarInfo i_Car,
                                    MotorcycleInfo i_Motorcycle,
                                    WheelInfo i_Wheel)
        {
            m_LicensePlate = i_License;
            m_OwnerDetails = i_Owner;
            m_vehicleUsersChoice = i_VehicleType;
            m_Model = i_Model;
            m_EnergyTypeInfo = i_EngineType;
            m_TruckInfo = i_Truck;
            m_CarInfo = i_Car;
            m_MotorCycleInfo = i_Motorcycle;
            m_WheelInfo = i_Wheel;
        }

        public string LicenseNumber
        {
            get { return m_LicensePlate; }
            set { m_LicensePlate = value; }
        }
        public OwnerDetails OwnerDetails
        {
            get { return m_OwnerDetails; }
            set { m_OwnerDetails = value; }
        }
        public eSupportedVehicles VehicleType
        {
            get { return m_vehicleUsersChoice; }
            set { m_vehicleUsersChoice = value; }
        }
        public string Model
        {
            get { return m_Model; }
            set { m_Model = value; }
        }
        public EnergyTypeInfo EngineType
        {
            get { return m_EnergyTypeInfo; }
            set { m_EnergyTypeInfo = value; }
        }

        public TruckInfo TruckDetails
        {
            set { m_TruckInfo = value; }
            get { return m_TruckInfo; }
        }
        public CarInfo CarDetails
        {
            get { return m_CarInfo; }
            set { m_CarInfo = value; }
        }
        public MotorcycleInfo MotorcycleDetails
        {
            get { return m_MotorCycleInfo; }
            set { m_MotorCycleInfo = value; }
        }
        public WheelInfo WheelDetails
        {
            get { return m_WheelInfo; }
            set { m_WheelInfo = value; }
        }
        
        //public struct OwnerInfo
        //{
        //    private string m_OwnerName;
        //    private string m_OwnerPhone;

        //    public OwnerInfo(string i_Name, string i_PhoneNumber)
        //    {
        //        m_OwnerName = i_Name;
        //        m_OwnerPhone = i_PhoneNumber;
        //    }

        //    public string getName
        //    {
        //        get { return m_OwnerName; }
        //    }
        //    public string getPhone
        //    {
        //        get { return m_OwnerPhone; }
        //    }
        //}
    }
}
