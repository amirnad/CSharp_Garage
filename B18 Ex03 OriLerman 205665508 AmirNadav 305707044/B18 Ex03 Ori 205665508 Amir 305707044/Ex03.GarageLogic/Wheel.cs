using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private readonly string r_manufacturer = string.Empty;
        private float m_currPsi = 0;
        private readonly float r_maxPsi;
        
        internal void  fillAir(float i_amountOfAir)
        {
            if(maxPsi<m_currPsi+i_amountOfAir)
            {
                m_currPsi += i_amountOfAir;
            }
            else
            {
                //    throw new ValueOutOfRangeException();/// add parameters when exeption ready
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
