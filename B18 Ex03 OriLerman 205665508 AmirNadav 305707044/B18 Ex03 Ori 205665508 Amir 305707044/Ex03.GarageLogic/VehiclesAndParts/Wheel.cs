using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_TyreManufacturer = string.Empty;
        private readonly float r_MaxTyrePsi;
        private float m_CurrentTyrePsi;

        public float CurrentPressure
        {
            get { return m_CurrentTyrePsi; }
        }

        public float MaximumPressure
        {
            get { return r_MaxTyrePsi; }
        }

        internal void fillAir(float i_amountOfAir)
        {
            if (m_CurrentTyrePsi + i_amountOfAir <= r_MaxTyrePsi)
            {
                m_CurrentTyrePsi += i_amountOfAir;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxTyrePsi - m_CurrentTyrePsi, "i_amountOfAir");
            }
        }

        public Wheel(WheelInfo i_Wheel)
        {
            r_TyreManufacturer = i_Wheel.Brand;
            r_MaxTyrePsi = i_Wheel.MaxTyrePressure;
            m_CurrentTyrePsi = i_Wheel.CurrentTyrePressure;
        }

        public override string ToString()
        {
            return string.Format("\tTyre Manufacturer: {1}{0}\tCurrent PSI: {2}{0}\tMaximum PSI: {3}{0}", Environment.NewLine, r_TyreManufacturer, m_CurrentTyrePsi, r_MaxTyrePsi);
        }
    }
}
