namespace PizzaShoppingAPI.Exceptions
{
    public class NoCustomersFoundException : Exception
    {
        string message;
        public NoCustomersFoundException()
        {
            message = "No Customers found!";
        }
        public NoCustomersFoundException(string name)
        {
            message = name;
        }
        public override string Message => message;
    }
}
