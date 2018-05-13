using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Fuel : EnergyType
    {  
        public enum eFuelType { Octan95, Octan96, Octan98, Soler}
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private readonly float r_MaxFuelAmount;

        public void Refuel(eFuelType i_Type, float i_FuelAmountToAdd)
        {
            if(i_Type == m_FuelType)
            {
                if(m_CurrentFuelAmount + i_FuelAmountToAdd <= r_MaxFuelAmount)
                {
                    m_CurrentFuelAmount += i_FuelAmountToAdd;
                }
                else
                {
                    //throw ValueOutOfRangeException;
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
