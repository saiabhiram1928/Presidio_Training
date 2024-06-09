namespace PizzaShoppingAPI.Exceptions
{
    public class NoSuchPizzaException : Exception
    {
        string message;
        public NoSuchPizzaException()
        {
            message = "No Pizza found!";
        }
        public NoSuchPizzaException(string name)
        {
            message = name;
        }
        public override string Message => message;
    }
}
