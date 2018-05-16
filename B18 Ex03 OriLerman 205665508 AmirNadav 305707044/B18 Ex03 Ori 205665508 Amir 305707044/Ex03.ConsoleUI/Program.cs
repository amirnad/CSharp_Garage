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
            GarageManagerForConsole gm = new GarageManagerForConsole();
            gm.RunGarage();

            //gm.ShowLicenseNumberByFilter(eRepairState.AllStates);
            //bool exists = gm.CheckIfVehicleExists("12221C");
            //gm.AddNewVehicle(setup);
            //gm.ShowLicenseNumberByFilter(eRepairState.InShop);
            //exists = gm.CheckIfVehicleExists("12221C");
            //gm.ShowAllDataOnVehicle("12221C");
            //gm.FillTyrePressure("12221C");
            //gm.RefuelGasVehicle("12221C", FuelEngine.eFuelType.Octan98, 20f);
            //gm.ChangeVehicleRepairState("12221C", eRepairState.Fixed);
            //gm.ShowAllDataOnVehicle("12221C");
            //gm.ShowLicenseNumberByFilter(eRepairState.AllStates);

            //gm.ShowLicenseNumberByFilter(eRepairState.Fixed);
            //gm.ShowLicenseNumberByFilter(eRepairState.AllStates);


            //Console.WriteLine(gm.GetAllDataOnVehicle("12221C"));

            //gm.RechargeElectricVehicle("12221C", 30f);

        }

        public static VehicleInitialDetails CreateNewSetup()
        {
            VehicleInitialDetails setup = new VehicleInitialDetails();
            List<VehicleInitialDetails.WheelsListInfo> myWheels = new List<VehicleInitialDetails.WheelsListInfo>();

            myWheels.Add(new VehicleInitialDetails.WheelsListInfo("pirelli", 14f, 32f));
            myWheels.Add(new VehicleInitialDetails.WheelsListInfo("pirelli", 14f, 32f));
            myWheels.Add(new VehicleInitialDetails.WheelsListInfo("pirelli", 14f, 32f));
            myWheels.Add(new VehicleInitialDetails.WheelsListInfo("pirelli", 14f, 32f));

            setup.m_CarInfo.m_Color = Car.eCarColors.Black;
            setup.m_CarInfo.m_NumberOfDoors = Car.eNumberOfDoors.Five;
            setup.m_EnergyTypeInfo.engine = Factory.eSupportedEngines.Fuel;
            setup.m_LicensePlate = "12221C";
            setup.m_Model = "323";
            setup.m_EnergyTypeInfo.m_CurrentAmountEnergy = 20f;
            setup.m_ownerInfo.m_OwnerName = "ori";
            setup.m_ownerInfo.m_OwnerPhone = "0523221702";
            setup.m_AllWheelsInfo = myWheels;



            return setup;

        }
    }
}
