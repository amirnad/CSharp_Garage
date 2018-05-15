using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class DataStructure
    {
        private Dictionary<String, Vehicle> vehiclesDictionary = new Dictionary<String, Vehicle>();
        private List<Vehicle> m_fixedList = new List<Vehicle>();
        private List<Vehicle> m_payedList = new List<Vehicle>();
        private List<Vehicle> m_InShopList = new List<Vehicle>();

        public Vehicle search(string LicenseNumber)
        {
            Vehicle theOneWeLookFor = vehiclesDictionary[LicenseNumber];
            return theOneWeLookFor;
        }

        public int Count
        {
            get { return vehiclesDictionary.Count; }
        }


        public bool DoesVehicleExists(string o_LicenseNumber)
        {
            return vehiclesDictionary.ContainsKey(o_LicenseNumber);
        }
        public void Add(Vehicle i_vehicle)
        {
            eRepairState repairState = i_vehicle.RepairState;
            if (repairState == eRepairState.Fixed)
            {
                m_fixedList.Add(i_vehicle);
            }
            else if (repairState == eRepairState.Payed)
            {
                m_payedList.Add(i_vehicle);
            }
            else if (repairState == eRepairState.InShop)
            {
                m_InShopList.Add(i_vehicle);
            }
            vehiclesDictionary.Add(i_vehicle.LicenseNumber, i_vehicle);
        }
        public void Remove(Vehicle i_vehicle)
        {
            eRepairState repairState = i_vehicle.RepairState;
            if (repairState == eRepairState.Fixed)
            {
                m_fixedList.Remove(i_vehicle);
            }
            else if (repairState == eRepairState.Payed)
            {
                m_payedList.Remove(i_vehicle);
            }
            else if (repairState == eRepairState.InShop)
            {
                m_InShopList.Remove(i_vehicle);
            }

            vehiclesDictionary.Remove(i_vehicle.LicenseNumber);
        }

        public string GetListOfLicenseNumbers(eRepairState i_RepairState)
        {
            StringBuilder returnedList = new StringBuilder();
            switch (i_RepairState)
            {
                case eRepairState.AllStates:
                    foreach (KeyValuePair<string, Vehicle> pair in vehiclesDictionary)
                    {
                        returnedList.AppendFormat(pair.Key);
                    }
                    if(vehiclesDictionary.Count == 0)
                    {
                        returnedList.AppendFormat("\tThere are no vehicles in the garage at the moment!{0}", Environment.NewLine);

                    }
                    break;
                case eRepairState.Fixed:
                    getListOfLicensePlates(m_fixedList, ref returnedList);
                    break;
                case eRepairState.InShop:
                    getListOfLicensePlates(m_InShopList, ref returnedList);
                    break;
                case eRepairState.Payed:
                    getListOfLicensePlates(m_payedList, ref returnedList);
                    break;

            }
            return returnedList.ToString();
        }

        private void getListOfLicensePlates(List<Vehicle> i_VehiclesList, ref StringBuilder o_ReturnedString)
        {
            foreach (Vehicle vehicle in i_VehiclesList)
            {
                o_ReturnedString.AppendFormat("\t{0}{1}", vehicle.LicenseNumber, Environment.NewLine);
            }
            if(i_VehiclesList.Count == 0)
            {
                o_ReturnedString.AppendFormat("\tThere are no vehicles in this list at the moment!{0}", Environment.NewLine);
            }
        }

        public List<Vehicle> getFixedList()
        {
            return m_fixedList;
        }
        public List<Vehicle> getPayedList()
        {
            return m_payedList;
        }
        public List<Vehicle> getInShopList()
        {
            return m_InShopList;
        }
    }
}
