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
        private float m_CurrentTyrePsi;
        private readonly float r_MaxTyrePsi;
        
        public float CurrentPressure
        {
            get { return m_CurrentTyrePsi; }
        }

        internal void fillAir(float i_amountOfAir)
        {
            if(m_CurrentTyrePsi + i_amountOfAir <= r_MaxTyrePsi)
            {
                m_CurrentTyrePsi += i_amountOfAir;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxTyrePsi - m_CurrentTyrePsi, "i_amountOfAir");
            }
        }
        public Wheel(string i_Manufacturer,float i_MaxPsi,float i_CurrentPsi)
        {
            r_TyreManufacturer = i_Manufacturer;
            r_MaxTyrePsi = i_MaxPsi;
            m_CurrentTyrePsi = i_CurrentPsi;
        }

        public override string ToString()
        {
            return string.Format("\tTyre Manufacturer: {1}{0}\tCurrent PSI: {2}{0}\tMaximum PSI: {3}{0}",Environment.NewLine, r_TyreManufacturer, m_CurrentTyrePsi, r_MaxTyrePsi);
        }
    }
}
