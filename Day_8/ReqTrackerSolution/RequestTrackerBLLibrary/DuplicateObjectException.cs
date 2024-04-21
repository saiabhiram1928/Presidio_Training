using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    internal class DuplicateObjectException:Exception
    {
        public DuplicateObjectException() : base("Duplicate object found.") { }
       

        public DuplicateObjectException(string message) : base(message) { }
        

        public DuplicateObjectException(string message, Exception innerException) : base(message, innerException) { }
        
        
    }
}
