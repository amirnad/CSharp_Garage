using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInitialDetails
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
            get { return m_TruckInfo; }
            set { m_TruckInfo = value; }
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
    }
}