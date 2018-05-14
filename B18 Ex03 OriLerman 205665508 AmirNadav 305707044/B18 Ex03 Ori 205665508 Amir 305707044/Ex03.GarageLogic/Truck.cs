using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        public const float k_MaxTruckPsi = 28;
        public const float k_MaxTruckFuel = 115;
        bool m_TrunkCooled;
        float m_TrunkVolume;
//        private Fuel m_TruckEnergyType;//maybe needs to be energy type if yes also constructo changes the parameter fuel

        public override float VehicleMaxPressure
        {
            get
            {
                return k_MaxTruckPsi;
            }
        }

        public Truck(bool i_TrunkCooled, float i_TrunkVolume, Fuel o_TypeOfEnergy, string o_ModelName, string o_LicensePlate, OwnerDetails o_TruckOwner, List<Wheel> o_Wheels) 
            : base(o_ModelName, o_LicensePlate, o_TruckOwner, o_Wheels)
        {
            m_TrunkCooled = i_TrunkCooled;
            m_TrunkVolume = i_TrunkVolume;
            m_EnergyType = o_TypeOfEnergy;
            EnergyRatio = o_TypeOfEnergy.CalculateRatio();
        }

    }
}
