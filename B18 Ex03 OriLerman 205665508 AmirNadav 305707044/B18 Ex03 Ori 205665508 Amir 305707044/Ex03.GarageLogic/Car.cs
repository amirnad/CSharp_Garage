using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public const float k_MaxCarPsi = 32;
        public const float k_MaxCarFuel = 45;
        public const float k_MaxCarElectricHours = 3.2f;
        public enum eCarColors { Gray = 1 , Blue, White, Black }
        public enum eNumberOfDoors { Two = 2, Three, Four, Five }


        private eCarColors m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        public override float VehicleMaxPressure
        {
            get
            {
                return k_MaxCarPsi;
            }
        }
        public Car(eCarColors i_ChosenColor, eNumberOfDoors i_CarDoors, EnergyType o_TypeOfEnergy, string o_ModelName, string o_LicensePlate, OwnerDetails o_CarOwner, List<Wheel> o_Wheels)
            : base(o_ModelName, o_LicensePlate, o_CarOwner, o_Wheels)
        {
            m_CarColor = i_ChosenColor;
            m_NumberOfDoors = i_CarDoors;
            m_EnergyType = o_TypeOfEnergy;
        }


        public override string ToString()
        {
            StringBuilder returnedString = new StringBuilder();
            returnedString.AppendFormat(base.ToString());
            returnedString.AppendFormat(m_OwnerDetails.ToString());
            returnedString.AppendFormat("Vehicle Type: Car{0}\tColor: {1}{0}\tNumber of Doors: {2}{0}", Environment.NewLine, m_CarColor, m_NumberOfDoors);
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
