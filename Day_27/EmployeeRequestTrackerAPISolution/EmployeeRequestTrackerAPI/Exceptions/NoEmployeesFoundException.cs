namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoEmployeesFoundException : Exception
    {
        string message;
        public NoEmployeesFoundException()
        {
            message = "No Employees found!";
        }
        public NoEmployeesFoundException(string name)
        {
            message = name;
        }
        public override string Message => message;
    }
}
