using System.Runtime.Serialization;

namespace ClinicApi.Exceptions
{
    public class NoDoctorsInDb:Exception
    {
        string msg = string.Empty;
        public NoDoctorsInDb()
        {
            msg = "No Doctors Present in the db";
        }

        public NoDoctorsInDb(string? message) : base(message)
        {
        }

        public NoDoctorsInDb(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoDoctorsInDb(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public override string Message => msg;
    }
}
