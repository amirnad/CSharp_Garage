using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eRepairState
    {
        AllStates,
        InShop,
        Fixed,
        Payed
    }

    public enum eVehicleWheels
    {
        MotorcycleWheels = 2,
        CarWheels = 4,
        TruckWheels = 12
    }

    public abstract class Vehicle       
    {
        private readonly string m_Model;
        private readonly string m_LicenseNumber;
        private readonly eVehicleWheels m_VehicleWheels;
        private eRepairState m_RepairState = eRepairState.InShop;
        protected List<Wheel> m_Wheels = null;
        protected OwnerDetails m_OwnerDetails;
        protected EnergyType m_EnergyType;

        public Vehicle(string io_Model, string io_LicenseNumber, OwnerDetails io_OwnerDetails, eVehicleWheels io_NumberOfWheels, List<Wheel> io_Wheels, EnergyType i_Engine)
        {
            m_Model = io_Model;
            m_LicenseNumber = io_LicenseNumber;
            m_OwnerDetails = io_OwnerDetails;
            m_VehicleWheels = io_NumberOfWheels;
            m_Wheels = io_Wheels;
            m_EnergyType = i_Engine;
        }

        public eRepairState RepairState
        {
            get { return m_RepairState; }
            set { m_RepairState = value; }
        }

        public EnergyType GetEnergySource
        {
            get { return m_EnergyType; }
        }

        public abstract float VehicleMaxPressure
        {
            get;
        }

        public void FillAirToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                float maxVehiclePsi = wheel.MaximumPressure;
                float currentWheelPsi = wheel.CurrentPressure;
                wheel.fillAir(maxVehiclePsi - currentWheelPsi);
            }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public override string ToString()
        {
            return string.Format("License Number: {0}\tModel: {2}\tRepair State: {3}{1}", m_LicenseNumber.ToString(), Environment.NewLine, m_Model, m_RepairState);
        }
    }
}
