using System.Runtime.Serialization;

namespace ClinicApi.Exceptions
{
    [Serializable]
    public class NoDoctorException : Exception
    {
        string msg =string.Empty;
        public NoDoctorException()
        {
            msg = "No Doctor With Given Id";
        }

        public NoDoctorException(string? message) : base(message)
        {
        }

        public NoDoctorException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoDoctorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public override string Message => msg;
    }
}
