using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ElectricityEngine : EnergyType
    {
        private readonly float r_MaxBatteryHoursLeft;
        private float m_CurrentBatteryHoursLeft;
        private float m_BatteryLifeRatio;

        public override void CalculateRatio()
        {
            const float k_Base = 100;
            m_BatteryLifeRatio = (m_CurrentBatteryHoursLeft / r_MaxBatteryHoursLeft) * k_Base;
        }

        public ElectricityEngine(float o_CurrentAmount, float o_MaxAmount)
        {
            m_CurrentBatteryHoursLeft = o_CurrentAmount;
            r_MaxBatteryHoursLeft = o_MaxAmount;
            CalculateRatio();
        }

        public void ReCharge(float i_ElectricityHoursToAdd)
        {
            const float k_MinutesInHour = 60;

            if (i_ElectricityHoursToAdd + m_CurrentBatteryHoursLeft <= r_MaxBatteryHoursLeft)
            {
                m_CurrentBatteryHoursLeft += i_ElectricityHoursToAdd;
                CalculateRatio();
            }
            else
            {
                throw new ValueOutOfRangeException(0, (r_MaxBatteryHoursLeft - m_CurrentBatteryHoursLeft) * k_MinutesInHour, "i_ElectricityHoursToAdd");
            }
        }

        public override string ToString()
        {
            return string.Format("Engine Type: Electric{0}\tBattery Life Percentage: {1}%{0}\tBattery Time Left: {2} Hours{0}\tMax Battery Time:{3} Hours{0}", Environment.NewLine, m_BatteryLifeRatio, m_CurrentBatteryHoursLeft, r_MaxBatteryHoursLeft);
        }
    }
}
