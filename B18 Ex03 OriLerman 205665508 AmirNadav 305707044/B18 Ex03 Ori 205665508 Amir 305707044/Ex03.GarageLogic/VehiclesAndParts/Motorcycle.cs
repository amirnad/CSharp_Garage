using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseTypes { A = 1, A1, A2, B1, B2 }
        public const float k_MaxMotorcyclePsi = 30;
        public const float k_MaxMotorcycleElectricHours = 1.8f;
        public const float k_MaxMotorcycleFuel = 6;

        private eLicenseTypes m_LicenseType;
        private int m_EngineVolume;

        public override float VehicleMaxPressure
        {
            get
            {
                return k_MaxMotorcyclePsi;
            }
        }
        public Motorcycle(
                        string o_Brand,
                        string o_LicenseNumber,
                        OwnerDetails o_Owner,
                        List<Wheel> o_Wheels,
                        MotorcycleInfo i_MotorcycleInfo,
                        EnergyType i_Engine) : base(o_Brand,o_LicenseNumber,o_Owner,eVehicleWheels.MotorcycleWheels,o_Wheels,i_Engine)
        {
            m_LicenseType = i_MotorcycleInfo.LicenseType;
            m_EngineVolume = i_MotorcycleInfo.EngineVolume;
        }


        public Motorcycle(eLicenseTypes o_LicenseType, int o_EngineVolume, EnergyType o_TypeOfEnergy, string o_ModelName, string o_LicensePlate, OwnerDetails o_MotorcycleOwner, List<Wheel> o_Wheels)
            : base(o_ModelName, o_LicensePlate, o_MotorcycleOwner,eVehicleWheels.MotorcycleWheels , o_Wheels, o_TypeOfEnergy)
        {
            m_LicenseType = o_LicenseType;
            m_EngineVolume = o_EngineVolume;
            m_EnergyType = o_TypeOfEnergy;
        }

        public override string ToString()
        {
            StringBuilder returnedString = new StringBuilder();
            returnedString.AppendFormat(base.ToString());
            returnedString.AppendFormat(m_OwnerDetails.ToString());
            returnedString.AppendFormat("Vehicle Type: Motorcycle{0}\tLicense Type: {1}\tEngine Volume: {2} cc{0}", Environment.NewLine, m_LicenseType, m_EngineVolume);
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
