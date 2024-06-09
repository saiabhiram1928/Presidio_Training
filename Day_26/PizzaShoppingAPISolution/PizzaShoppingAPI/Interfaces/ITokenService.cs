using PizzaShoppingAPI.Models;
namespace PizzaShoppingAPI.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Customer customer);
    }
}
