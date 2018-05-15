using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseTypes { A,A1,A2,B1,B2 }
        public const float k_MaxMotorcyclePsi = 30;
        public const float k_MaxMotorcycleElectricHours = 1.8f;
        public const float k_MaxMotorcycleFuel = 6;
        private eLicenseTypes m_licenseType;
        private int m_engineVolume;

        public override float VehicleMaxPressure
        {
            get
            {
                return k_MaxMotorcyclePsi;
            }
        }

        public Motorcycle(eLicenseTypes o_LicenseType,int o_EngineVolume, EnergyType o_TypeOfEnergy, string o_ModelName, string o_LicensePlate, OwnerDetails o_MotorcycleOwner, List<Wheel> o_Wheels) 
            : base(o_ModelName, o_LicensePlate, o_MotorcycleOwner, o_Wheels)
        {
            m_licenseType = o_LicenseType;
            m_engineVolume = o_EngineVolume;
            m_EnergyType = o_TypeOfEnergy;
        }

        public override string ToString()
        {
            StringBuilder returnedString = new StringBuilder();
            returnedString.AppendFormat(base.ToString());
            returnedString.AppendFormat(m_OwnerDetails.ToString());
            returnedString.AppendFormat("Vehicle Type: Motorcycle{0}\tLicense Type: {1}\tEngine Volume: {2} cc{0}", Environment.NewLine, m_licenseType, m_engineVolume);
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
