using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class OwnerDetails
    {
        private string m_name;
        private string m_phone;

        public OwnerDetails(string io_name, string io_Phone)
        {
            m_name = io_name;
            m_phone = io_Phone;
        }
    }
}
