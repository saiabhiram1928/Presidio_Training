namespace PizzaShoppingAPI.Exceptions
{
    public class NoSuchCustomerException : Exception
    {
        string message;
        public NoSuchCustomerException()
        {
            message = "No Customer found!";
        }
        public NoSuchCustomerException(string name)
        {
            message = name;
        }
        public override string Message => message;

    }
}
