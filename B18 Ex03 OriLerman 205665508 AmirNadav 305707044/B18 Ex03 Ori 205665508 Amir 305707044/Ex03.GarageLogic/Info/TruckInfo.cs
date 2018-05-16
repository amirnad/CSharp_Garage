namespace Ex03.GarageLogic
{
    public struct TruckInfo
    {
        private bool m_TruckCooled;
        private float m_TrunkVolume;

        public TruckInfo(bool i_IsCooled, float i_TrunkVolume)
        {
            m_TruckCooled = i_IsCooled;
            m_TrunkVolume = i_TrunkVolume;
        }
        public bool IsCooled
        {
            get { return m_TruckCooled; }
        }
        public float TrunkVolume
        {
            get { return m_TrunkVolume; }
        }

    }
}