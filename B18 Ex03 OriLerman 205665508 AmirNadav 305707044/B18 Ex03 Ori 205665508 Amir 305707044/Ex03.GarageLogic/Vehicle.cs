using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eRepairState { InShop, Fixed, Payed , AllStates}
    public abstract class Vehicle
    {
        protected readonly string m_Model;
        protected readonly string m_LicenseNumber;
      //  private float m_EnergyRatio = 0;
        protected List<Wheel> m_Wheels = null;//initailizes in son
        protected OwnerDetails m_OwnerDetails;
        private eRepairState m_RepairState = eRepairState.InShop;
        protected EnergyType m_EnergyType;

        public Vehicle(string io_Model, string io_LicenseNumber, OwnerDetails io_OwnerDetails, List<Wheel> io_Wheels)
        {
            m_Model = io_Model;
            m_LicenseNumber = io_LicenseNumber;
            m_OwnerDetails = io_OwnerDetails;
            m_Wheels = io_Wheels;
        }
        //protected float EnergyRatio
        //{
        //    get { return m_EnergyRatio; }
        //    set
        //    {
        //        m_EnergyRatio = value;
        //    }
        //}
        public eRepairState RepairState
        {
            get { return m_RepairState; }
            set
            {
                m_RepairState = value;
            }
        }
        public EnergyType GetEnergySource
        {
            get { return m_EnergyType; }
        }
        public abstract float VehicleMaxPressure
        {
            get;
        }
        public void FillAirToMax()
        {
            float maxVehiclePsi = VehicleMaxPressure;
            foreach(Wheel wheel in m_Wheels)
            {
                float currentWheelPsi = wheel.CurrentPressure;
                wheel.fillAir(maxVehiclePsi - currentWheelPsi);

            }
        }
        internal string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }

        public override string ToString()
        {
            return string.Format("License Number: {0}\tModel: {2}\tRepair State: {3}{1}", m_LicenseNumber.ToString(), Environment.NewLine, m_Model, m_RepairState);
        }
    }
    //public class program
    //{
    //    public static void Main()
    //    {
    //        VehicleInitialDetails setup = CreateNewSetup();

    //        Vehicle myCar = Factory.createNewVehicle(ref setup);

    //        Wheel wh = new Wheel("ori", 12, 12);
    //        List<Wheel> l = new List<Wheel>();
    //        Vehicle vh = new Truck(true, 12, new Fuel(Fuel.eFuelType.Octan95, 12, 14), "o", "123", new OwnerDetails("ori", "052"), l);
    //        OwnerDetails od = new OwnerDetails("ol", "052");
    //        DataStructure ds = new DataStructure();

    //        garageManager gm = new garageManager();
    //        bool exists = gm.CheckIfVehicleExists("12221C");
    //        gm.AddNewVehicle(setup);
    //        exists = gm.CheckIfVehicleExists("12221C");
    //        gm.ChangeVehicleRepairState("12221C", eRepairState.Fixed);
    //        gm.FillTyrePressure("12221C");


    //    }

    //    public static VehicleInitialDetails CreateNewSetup()
    //    {
    //        VehicleInitialDetails setup = new VehicleInitialDetails();
    //        List<VehicleInitialDetails.wheelsInfo> myWheels = new List<VehicleInitialDetails.wheelsInfo>();

    //        myWheels.Add(new VehicleInitialDetails.wheelsInfo("pirelli", 14f));
    //        myWheels.Add(new VehicleInitialDetails.wheelsInfo("pirelli", 14f));
    //        myWheels.Add(new VehicleInitialDetails.wheelsInfo("pirelli", 14f));
    //        myWheels.Add(new VehicleInitialDetails.wheelsInfo("pirelli", 14f));



    //        setup.m_CarInfo.m_Color = Car.eCarColors.Black;
    //        setup.m_CarInfo.m_NumberOfDoors = Car.eNumberOfDoors.Five;
    //        setup.m_EnergyTypeInfo.engine = Factory.eSupportedEngines.Electric;
    //        setup.m_LicensePlate = "12221C";
    //        setup.m_Model = "323";
    //        setup.m_EnergyTypeInfo.m_CurrentAmountEnergy = 6;
    //        setup.m_ownerInfo.m_OwnerName = "ori";
    //        setup.m_ownerInfo.m_OwnerPhone = "0523221702";
    //        setup.m_WheelsInfoList = myWheels;
    //        return setup;

    //    }
    //}
}
