using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private readonly string r_manufacturer = string.Empty;
        private float m_currPsi;
        private readonly float r_MaxPsi;
        
        public float CurrentPressure
        {
            get { return m_currPsi; }
        }

        internal void fillAir(float i_amountOfAir)
        {
            if(m_currPsi + i_amountOfAir <= r_MaxPsi)
            {
                m_currPsi += i_amountOfAir;
            }
            else
            {
                throw new ValueOutOfRangeException(0,r_MaxPsi-m_currPsi, "i_amountOfAir");
            }
        }
        public Wheel(string io_manufacturer,float io_MaxPsi,float io_currPsi)
        {
            r_manufacturer = io_manufacturer;
            r_MaxPsi = io_MaxPsi;
            m_currPsi = io_currPsi;
        }
    }
}
