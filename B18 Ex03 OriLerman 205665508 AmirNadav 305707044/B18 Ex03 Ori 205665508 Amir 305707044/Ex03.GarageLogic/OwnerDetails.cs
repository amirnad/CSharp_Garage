using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class OwnerDetails
    {
        private string m_Name;
        private string m_PhoneNumber;

        public OwnerDetails(string i_Name, string i_PhoneNumber)
        {
            m_Name = i_Name;
            m_PhoneNumber = i_PhoneNumber;
        }

        public override string ToString()
        {
            return string.Format("Owner{0}\tName: {1}{0}\tPhone Number: {2}{0}", Environment.NewLine, m_Name, m_PhoneNumber);
        }
    }
}
