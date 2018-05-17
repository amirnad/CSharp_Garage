namespace Ex03.GarageLogic
{
    public struct MotorcycleInfo
    {
        private Motorcycle.eLicenseTypes m_licenceType;
        private int m_EngineVolume;

        public MotorcycleInfo(Motorcycle.eLicenseTypes i_License, int i_EngineVolume)
        {
            m_licenceType = i_License;
            m_EngineVolume = i_EngineVolume;
        }

        public Motorcycle.eLicenseTypes LicenseType
        {
            get { return m_licenceType; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
        }
    }
}
