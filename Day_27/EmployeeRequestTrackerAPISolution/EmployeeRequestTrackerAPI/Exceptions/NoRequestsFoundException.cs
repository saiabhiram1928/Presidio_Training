namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoRequestsFoundException : Exception
    {
        string message;
        public NoRequestsFoundException()
        {
            message = "No Requests found!";
        }
        public NoRequestsFoundException(string name)
        {
            message = name;
        }
        public override string Message => message;
    }
}
