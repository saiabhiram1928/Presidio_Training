namespace PizzaShoppingAPI.Exceptions
{
    public class NoSuchUserException : Exception
    {
        string message;
        public NoSuchUserException()
        {
            message = "No User found!";
        }
        public NoSuchUserException(string name)
        {
            message = name;
        }
        public override string Message => message;

    }
}
