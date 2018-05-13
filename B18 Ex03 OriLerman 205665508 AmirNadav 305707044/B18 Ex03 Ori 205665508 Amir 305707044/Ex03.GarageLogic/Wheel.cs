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
        
        internal void  fillAir(float i_amountOfAir)
        {
            if(r_MaxPsi<m_currPsi+i_amountOfAir)
            {
                m_currPsi += i_amountOfAir;
            }
            else
            {
                //throw new ValueOutOfRangeException();/// add parameters when exeption ready
                throw new ArgumentOutOfRangeException();
            }
        }
        public Wheel(string io_manufacturer,float io_MaxPsi,float io_currPsi)
        {
            r_manufacturer = io_manufacturer;
            r_MaxPsi = io_MaxPsi;
            m_currPsi = 0;
        }
    }
}
