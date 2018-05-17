using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehiclesGarage
    {
        private Dictionary<string, Vehicle> m_VehiclesDictionary = new Dictionary<string, Vehicle>();
        private List<Vehicle> m_fixedList = new List<Vehicle>();
        private List<Vehicle> m_payedList = new List<Vehicle>();
        private List<Vehicle> m_InShopList = new List<Vehicle>();

        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            Vehicle theOneWeLookFor = m_VehiclesDictionary[i_LicenseNumber];
            return theOneWeLookFor;
        }

        public int Count
        {
            get { return m_VehiclesDictionary.Count; }
        }

        public bool DoesVehicleExists(string i_LicenseNumber)
        {
            return m_VehiclesDictionary.ContainsKey(i_LicenseNumber);
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

            m_VehiclesDictionary.Add(i_vehicle.LicenseNumber, i_vehicle);
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

            m_VehiclesDictionary.Remove(i_vehicle.LicenseNumber);
        }

        public Dictionary<string, Vehicle> GetWholeGarage()
        {
            return m_VehiclesDictionary;
        }

        public List<Vehicle> GetFixedList()
        {
            return m_fixedList;
        }

        public List<Vehicle> GetPayedList()
        {
            return m_payedList;
        }

        public List<Vehicle> GetInShopList()
        {
            return m_InShopList;
        }
    }
}
