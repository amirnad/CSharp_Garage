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
 //       private EnergyType m_MotorcycleEnergyType;

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
            EnergyRatio = o_TypeOfEnergy.CalculateRatio();
        }
    }
}
