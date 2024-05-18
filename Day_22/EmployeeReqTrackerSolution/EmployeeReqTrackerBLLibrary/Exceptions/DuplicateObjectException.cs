using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerBLLibrary.Exceptions
{
    public class DuplicateObjectException : Exception
    {
        public DuplicateObjectException() : base("Duplicate obj found.") { }


        public DuplicateObjectException(string message) : base(message) { }


        public DuplicateObjectException(string message, Exception innerException) : base(message, innerException) { }
    }
}
