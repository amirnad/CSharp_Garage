namespace Ex03.GarageLogic
{
    public struct CarInfo
    {
        private Car.eCarColors m_Color;
        private Car.eNumberOfDoors m_NumberOfDoors;

        public CarInfo(Car.eCarColors i_Color, Car.eNumberOfDoors i_NumberOfDoors)
        {
            m_Color = i_Color;
            m_NumberOfDoors = i_NumberOfDoors;
        }
        public Car.eCarColors Color
        {
            get { return m_Color; }
        }
        public Car.eNumberOfDoors Doors
        {
            get { return m_NumberOfDoors; }
        }
    }
}
