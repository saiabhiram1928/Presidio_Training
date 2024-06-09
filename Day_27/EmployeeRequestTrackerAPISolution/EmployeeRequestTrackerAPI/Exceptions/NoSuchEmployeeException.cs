namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoSuchEmployeeException : Exception
    {
        string message;
        public NoSuchEmployeeException()
        {
            message = "No Employee found!";
        }
        public NoSuchEmployeeException(string name)
        {
            message = name;
        }
        public override string Message => message;

    }
}
