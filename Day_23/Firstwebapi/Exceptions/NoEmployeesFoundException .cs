﻿using System.Runtime.Serialization;

namespace Firstwebapi.Exceptions
{
    [Serializable]
    public class NoEmployeesFoundException:Exception
    {
        public NoEmployeesFoundException()
        {
        }

        public NoEmployeesFoundException(string? message) : base(message)
        {
        }

        public NoEmployeesFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoEmployeesFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
