using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {


            VehicleInitialDetails setup = CreateNewSetup();

            GarageManager gm = new GarageManager();
            bool exists = gm.CheckIfVehicleExists("12221C");
            gm.AddNewVehicle(setup);
            exists = gm.CheckIfVehicleExists("12221C");
            gm.ChangeVehicleRepairState("12221C", eRepairState.Fixed);
            gm.FillTyrePressure("12221C");
            gm.RefuelVehicle("12221C", Fuel.eFuelType.Octan98, 30f);

        }

        public static VehicleInitialDetails CreateNewSetup()
        {
            VehicleInitialDetails setup = new VehicleInitialDetails();
            List<VehicleInitialDetails.wheelsInfo> myWheels = new List<VehicleInitialDetails.wheelsInfo>();

            myWheels.Add(new VehicleInitialDetails.wheelsInfo("pirelli", 14f));
            myWheels.Add(new VehicleInitialDetails.wheelsInfo("pirelli", 14f));
            myWheels.Add(new VehicleInitialDetails.wheelsInfo("pirelli", 14f));
            myWheels.Add(new VehicleInitialDetails.wheelsInfo("pirelli", 14f));



            setup.m_CarInfo.m_Color = Car.eCarColors.Black;
            setup.m_CarInfo.m_NumberOfDoors = Car.eNumberOfDoors.Five;
            setup.m_EnergyTypeInfo.engine = Factory.eSupportedEngines.Electric;
            setup.m_LicensePlate = "12221C";
            setup.m_Model = "323";
            setup.m_EnergyTypeInfo.m_CurrentAmountEnergy = 2f;
            setup.m_ownerInfo.m_OwnerName = "ori";
            setup.m_ownerInfo.m_OwnerPhone = "0523221702";
            setup.m_WheelsInfoList = myWheels;
            return setup;

        }
    }
}
