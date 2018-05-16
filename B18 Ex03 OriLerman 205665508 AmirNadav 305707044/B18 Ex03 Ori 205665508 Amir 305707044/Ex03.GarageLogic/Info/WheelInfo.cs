namespace Ex03.GarageLogic
{
    public struct WheelInfo
    {
        private string m_TyreManufacturer;
        private float m_TyreMaxPsi;
        private float m_TyreCurrentPsi;

        public WheelInfo(string i_Manufacturer, float i_MaximumPsi, float i_CurrentPsi)
        {
            m_TyreManufacturer = i_Manufacturer;
            m_TyreMaxPsi = i_MaximumPsi;
            m_TyreCurrentPsi = i_CurrentPsi;
        }

        public string Brand
        {
            get { return m_TyreManufacturer; }
        }

        public float MaxTyrePressure
        {
            get { return m_TyreMaxPsi; }
        }

        public float CurrentTyrePressure
        {
            get { return m_TyreCurrentPsi; }
        }
    }
}
