namespace PizzaShoppingAPI.Exceptions
{
    public class NoPizzasFoundException : Exception
    {
        string message;
        public NoPizzasFoundException()
        {
            message = "No Pizzas found!";
        }
        public NoPizzasFoundException(string name)
        {
            message = name;
        }
        public override string Message => message;
    }
}
