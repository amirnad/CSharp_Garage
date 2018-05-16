using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eRepairState { AllStates, InShop, Fixed, Payed }
    public enum eVehicleWheels { MotorcycleWheels = 2, CarWheels = 4, TruckWheels = 12 };
    public abstract class Vehicle
    {
        //public static readonly int k_CarWheels = 4;
        //public static readonly int k_MotorcycleWheels = 2;
        //public static readonly int k_TruckWheels = 12;

        private readonly string m_Model;
        private readonly string m_LicenseNumber;
        private readonly eVehicleWheels m_VehicleWheels;
        private eRepairState m_RepairState = eRepairState.InShop;
        //  private float m_EnergyRatio = 0;
        protected List<Wheel> m_Wheels = null;//initailizes in son
        protected OwnerDetails m_OwnerDetails;
        protected EnergyType m_EnergyType;

        public Vehicle(string io_Model, string io_LicenseNumber, OwnerDetails io_OwnerDetails, eVehicleWheels io_NumberOfWheels, List<Wheel> io_Wheels, EnergyType i_Engine)
        {
            m_Model = io_Model;
            m_LicenseNumber = io_LicenseNumber;
            m_OwnerDetails = io_OwnerDetails;
            m_VehicleWheels = io_NumberOfWheels;
            m_Wheels = io_Wheels;
            m_EnergyType = i_Engine;
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
            foreach (Wheel wheel in m_Wheels)
            {
                float maxVehiclePsi = wheel.MaximumPressure;
                float currentWheelPsi = wheel.CurrentPressure;
                wheel.fillAir(maxVehiclePsi - currentWheelPsi);

            }
        }
        public string LicenseNumber
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
    //        Vehicle vh = new Truck(true, 12, new FuelEngine(FuelEngine.eFuelType.Octan95, 12, 14), "o", "123", new OwnerDetails("ori", "052"), l);
    //        OwnerDetails od = new OwnerDetails("ol", "052");
    //        VehiclesGarage ds = new VehiclesGarage();

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
    //        List<VehicleInitialDetails.WheelsListInfo> myWheels = new List<VehicleInitialDetails.WheelsListInfo>();

    //        myWheels.Add(new VehicleInitialDetails.WheelsListInfo("pirelli", 14f));
    //        myWheels.Add(new VehicleInitialDetails.WheelsListInfo("pirelli", 14f));
    //        myWheels.Add(new VehicleInitialDetails.WheelsListInfo("pirelli", 14f));
    //        myWheels.Add(new VehicleInitialDetails.WheelsListInfo("pirelli", 14f));



    //        setup.m_CarInfo.m_Color = Car.eCarColors.Black;
    //        setup.m_CarInfo.m_NumberOfDoors = Car.eNumberOfDoors.Five;
    //        setup.m_EnergyTypeInfo.engine = Factory.eSupportedEngines.Electric;
    //        setup.m_LicensePlate = "12221C";
    //        setup.m_Model = "323";
    //        setup.m_EnergyTypeInfo.m_CurrentAmountEnergy = 6;
    //        setup.m_OwnerDetails.m_OwnerName = "ori";
    //        setup.m_OwnerDetails.m_OwnerPhone = "0523221702";
    //        setup.m_AllWheelsInfo = myWheels;
    //        return setup;

    //    }
    //}
}
