using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColors { Gray, Blue, White, Black }
        public enum eNumberOfDoors { Two = 2, Three, Four, Five }
        private eCarColors m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
        EnergyType m_CarEnergyType;

        Car(eCarColors i_ChosenColor, eNumberOfDoors i_CarDoors, EnergyType o_TypeOfEnergy, string o_ModelName, string o_LicensePlate, List<Wheel> o_Wheels, OwnerDetails o_CarOwner) : base(o_ModelName, o_LicensePlate, o_Wheels, o_CarOwner)
        {
            m_CarColor = i_ChosenColor;
            m_NumberOfDoors = i_CarDoors;
            m_CarEnergyType = o_TypeOfEnergy;
        }
    }
}
