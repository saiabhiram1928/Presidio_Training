namespace Firstwebapi.Exceptions
{
    [Serializable]
    public class NoSuchEmployeeException:Exception
    {
        string message;
        public NoSuchEmployeeException()
        {
            message = "No such employee present";
        }

        public override string Message => message;
    }
}
