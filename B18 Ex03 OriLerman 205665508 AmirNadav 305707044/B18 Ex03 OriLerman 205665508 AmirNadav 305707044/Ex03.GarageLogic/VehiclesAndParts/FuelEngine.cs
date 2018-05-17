using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : EnergyType
    {
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        private readonly float r_MaxFuelAmount;
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_FuelRatio;

        public override void CalculateRatio()
        {
            const float k_Base = 100;
            m_FuelRatio = (m_CurrentFuelAmount / r_MaxFuelAmount) * k_Base;
        }

        public FuelEngine(eFuelType o_TypeOfFuel, float o_CurrentAmount, float o_MaxAmount)
        {
            m_FuelType = o_TypeOfFuel;
            m_CurrentFuelAmount = o_CurrentAmount;
            r_MaxFuelAmount = o_MaxAmount;
            CalculateRatio();
        }

        public void Refuel(eFuelType i_Type, float i_FuelAmountToAdd)
        {
            if (i_Type == m_FuelType)
            {
                if (m_CurrentFuelAmount + i_FuelAmountToAdd <= r_MaxFuelAmount)
                {
                    m_CurrentFuelAmount += i_FuelAmountToAdd;
                    CalculateRatio();
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_MaxFuelAmount - m_CurrentFuelAmount, "i_FuelAmountToAdd");
                }
            }
            else
            {
                throw new ArgumentException(string.Format("the {0} is invalid For this Vehicle", i_Type), i_Type.ToString());
            }
        }

        public override string ToString()
        {
            return string.Format("Engine Type: {0}\tFuel Type: {1}{0}\tFuel Percentage: {2}%{0}\tCurrent Fuel Amount: {3} Liters{0}\tMaximum Fuel Amount: {4} Liters{0}", Environment.NewLine, m_FuelType, m_FuelRatio, m_CurrentFuelAmount, r_MaxFuelAmount);
        }
    }
}
