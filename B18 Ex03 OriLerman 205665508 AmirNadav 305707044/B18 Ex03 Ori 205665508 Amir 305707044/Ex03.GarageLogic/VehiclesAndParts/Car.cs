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

        public enum eCarColors
        {
            Gray = 1,
            Blue,
            White,
            Black
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        private eCarColors m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        public override float VehicleMaxPressure
        {
            get
            {
                return k_MaxCarPsi;
            }
        }

        public Car(
                string o_Brand,
                string o_LicenseNumber,
                OwnerDetails o_Owner,
                List<Wheel> o_Wheels,
                CarInfo i_CarInfo,
                EnergyType i_Engine) : base(o_Brand, o_LicenseNumber, o_Owner, eVehicleWheels.CarWheels, o_Wheels, i_Engine)
        {
            m_CarColor = i_CarInfo.Color;
            m_NumberOfDoors = i_CarInfo.Doors;
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
