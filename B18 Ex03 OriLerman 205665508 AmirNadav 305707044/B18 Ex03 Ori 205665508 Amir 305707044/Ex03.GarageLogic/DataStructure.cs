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
