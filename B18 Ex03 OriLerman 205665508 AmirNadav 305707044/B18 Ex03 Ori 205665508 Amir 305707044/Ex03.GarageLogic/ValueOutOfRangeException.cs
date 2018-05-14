using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    /// <summary>
    /// ArgumentOutOfRangeException class inherits Exception
    /// </summary>
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;
        private string m_Message;

        public ValueOutOfRangeException(float i_MinValue,float i_MaxValue,string i_paramName)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;

            string Message = string.Format( "the input range for {2} is between {0} and {1}",i_MinValue,i_MaxValue,i_paramName);
        }

        public override string Message
        {
            get { return m_Message; }
        }
    }
}
