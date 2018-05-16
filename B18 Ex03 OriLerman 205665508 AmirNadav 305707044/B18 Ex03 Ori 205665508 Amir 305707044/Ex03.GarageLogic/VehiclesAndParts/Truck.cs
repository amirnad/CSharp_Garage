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
        private bool m_TrunkCooled;
        private float m_TrunkVolume;

        public override float VehicleMaxPressure
        {
            get
            {
                return k_MaxTruckPsi;
            }
        }
        public Truck(
                    string o_Brand,
                    string o_LicenseNumber,
                    OwnerDetails o_Owner,
                    List<Wheel> o_Wheels,
                    TruckInfo i_TruckInfo,
                    FuelEngine i_Engine) : base(o_Brand,o_LicenseNumber,o_Owner,eVehicleWheels.TruckWheels, o_Wheels, i_Engine)
        {
            m_TrunkCooled = i_TruckInfo.IsCooled;
            m_TrunkVolume = i_TruckInfo.TrunkVolume;
        }
                    


        public Truck(bool i_TrunkCooled, float i_TrunkVolume, FuelEngine o_TypeOfEnergy, string o_ModelName, string o_LicensePlate, OwnerDetails o_TruckOwner, List<Wheel> o_Wheels)
            : base(o_ModelName, o_LicensePlate, o_TruckOwner, eVehicleWheels.TruckWheels, o_Wheels, o_TypeOfEnergy)
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
