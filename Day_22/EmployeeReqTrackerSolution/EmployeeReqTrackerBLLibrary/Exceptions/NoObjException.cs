using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerBLLibrary.Exceptions
{
    internal class NoObjException : Exception
    {
        public NoObjException() : base("No object found.") { }


        public NoObjException(string message) : base(message) { }


        public NoObjException(string message, Exception innerException) : base(message, innerException) { }
    }
}
