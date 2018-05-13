using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class ElectricityEngine : EnergyType
    {
        public enum eFuelType { Octan95, Octan96, Octan98, Soler }

        private float m_CurrentBatteryHoursLeft;
        private readonly float r_MaxBatteryHoursLeft;

        public override float CalculateRatio()
        {
            return m_CurrentBatteryHoursLeft / r_MaxBatteryHoursLeft;
        }

        public ElectricityEngine(float o_CurrentAmount,float o_MaxAmount)
        {
            m_CurrentBatteryHoursLeft = o_CurrentAmount;
            r_MaxBatteryHoursLeft = o_MaxAmount;

        }

        public void ReCharge(float i_ElectricityHoursToAdd)
        {
            if(i_ElectricityHoursToAdd+m_CurrentBatteryHoursLeft<r_MaxBatteryHoursLeft)
            {
                m_CurrentBatteryHoursLeft += i_ElectricityHoursToAdd;
            }
            else if(i_ElectricityHoursToAdd>0)
            {
                m_CurrentBatteryHoursLeft = r_MaxBatteryHoursLeft;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
