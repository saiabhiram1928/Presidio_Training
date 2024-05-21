using System.Runtime.Serialization;

namespace ClinicApi.Exceptions
{
    public class NoDocWithSpec:Exception
    {
        string msg = string.Empty;
        public NoDocWithSpec()
        {
            msg = "No Doctors With Given Sepecailization";
        }

        public NoDocWithSpec(string? message) : base(message)
        {
        }

        public NoDocWithSpec(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoDocWithSpec(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public override string Message => msg;
    }
}
