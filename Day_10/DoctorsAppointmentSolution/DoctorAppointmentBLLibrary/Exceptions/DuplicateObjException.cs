using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary.Exceptions
{
    internal class DuplicateObjException : Exception
    {
        public DuplicateObjException() : base("Duplicate object found.") { }


        public DuplicateObjException(string message) : base(message) { }


        public DuplicateObjException(string message, Exception innerException) : base(message, innerException) { }
    }
}
