using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eRepairState { InShop, Fixed, Payed }
    public abstract class Vehicle
    {
        protected readonly string m_Model;
        protected readonly string m_LicenseNumber;
        private float m_EnergyRatio = 0;
        protected List<Wheel> m_Wheels=null;//initailizes in son
        protected OwnerDetails m_OwnerDetails;
        private eRepairState m_RepairState = eRepairState.InShop;

        public Vehicle(string io_Model,string io_LicenseNumber,OwnerDetails io_OwnerDetails,List<Wheel> io_Wheels)
        {
            m_Model = io_Model;
            m_LicenseNumber = io_LicenseNumber;
            m_OwnerDetails = io_OwnerDetails;
            m_Wheels = io_Wheels;
        }
        protected float EnergyRatio
        {
            get { return m_EnergyRatio; }
            set
            {
                m_EnergyRatio = value;
            }
        }
        public eRepairState RepairState
        {
            get { return m_RepairState; }
            protected set
            {
                m_RepairState = value;
            }
        }
        internal string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }
        public KeyValuePair<string,Vehicle> ToPair()
        {
            KeyValuePair<string, Vehicle> returnedPair = new KeyValuePair<string, Vehicle>(m_LicenseNumber, this);
            return returnedPair;
        }

    }
    public class program
    {
        public static void Main()
        {
            Vehicle vh;

            Wheel wh = new Wheel("ori",12,12);
            OwnerDetails od = new OwnerDetails("ol","052");

        }

    }
}
