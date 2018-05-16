namespace Ex03.GarageLogic
{
    public struct EnergyTypeInfo
    {
        private float m_CurrentAmountEnergy;
        private eSupportedEngines m_Engine;

        public EnergyTypeInfo(float i_CurrentEnergyAmount, eSupportedEngines i_EngineType)
        {
            m_CurrentAmountEnergy = i_CurrentEnergyAmount;
            m_Engine = i_EngineType;
        }

        public float CurrentEnergy
        {
            get { return m_CurrentAmountEnergy; }
        }

        public eSupportedEngines Type
        {
            get { return m_Engine; }
        }
    }
}
