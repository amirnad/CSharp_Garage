using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public enum eIsCooled { No, Yes };
        public const float k_MaxTruckPsi = 28;
        public const float k_MaxTruckFuel = 115;
        bool m_TrunkCooled;
        float m_TrunkVolume;

        public override float VehicleMaxPressure
        {
            get
            {
                return k_MaxTruckPsi;
            }
        }

        public Truck(bool i_TrunkCooled, float i_TrunkVolume, FuelEngine o_TypeOfEnergy, string o_ModelName, string o_LicensePlate, OwnerDetails o_TruckOwner, List<Wheel> o_Wheels) 
            : base(o_ModelName, o_LicensePlate, o_TruckOwner, o_Wheels)
        {
            m_TrunkCooled = i_TrunkCooled;
            m_TrunkVolume = i_TrunkVolume;
            m_EnergyType = o_TypeOfEnergy;
        }

        public override string ToString()
        {
            StringBuilder returnedString = new StringBuilder();
            returnedString.AppendFormat(base.ToString());
            returnedString.AppendFormat(m_OwnerDetails.ToString());
            returnedString.AppendFormat("Vehicle Type: Truck{0}\tTrunk Cooled: {1}{0}\tTrunk Capacity: {2}", Environment.NewLine, m_TrunkCooled ? "Yes" : "No", m_TrunkVolume);
            returnedString.AppendFormat(m_EnergyType.ToString());
            returnedString.AppendFormat("Wheels:{0}", Environment.NewLine);
            foreach (Wheel wheel in m_Wheels)
            {
                returnedString.AppendFormat(wheel.ToString());
            }
            return returnedString.ToString();
        }
    }
}
