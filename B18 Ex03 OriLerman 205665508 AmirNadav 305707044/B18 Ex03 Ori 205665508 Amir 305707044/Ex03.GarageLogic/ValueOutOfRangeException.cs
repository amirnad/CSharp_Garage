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
    class ValueOutOfRangeException : Exception
    {
        float m_MaxValue;
        float m_MinValue;
        public ValueOutOfRangeException(float i_MinValue,float i_MaxValue,string i_paramName)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;

        }
        
         
    }
}
