namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoSuchRequestException : Exception
    {
        string message;
        public NoSuchRequestException()
        {
            message = "No Request found with given ID!";
        }
        public NoSuchRequestException(string name)
        {
            message = name;
        }
        public override string Message => message;
    }
}
