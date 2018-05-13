using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    enum eRepairState { InShop, Fixed, Payed }
    abstract class Vehicle
    {
        protected readonly string m_Model;//initailized in sons
        protected readonly string m_LicenseNumber;//initailized in sons
        private float m_EnergyRatio = 0;
        protected List<Wheel> m_Wheels = null;
        private OwnerDetails m_OwnerDetails = new OwnerDetails();
        private eRepairState m_RepairState = eRepairState.InShop;

        protected float EnergyRatio
        {
            get { return m_EnergyRatio; }
            set
            {
                m_EnergyRatio = value;
            }

        }

    }
    public class program
    {
        public static void Main()
        {
            Vehicle vh;

            Wheel wh = new Wheel();
            OwnerDetails od = new OwnerDetails();

        }

    }
}
