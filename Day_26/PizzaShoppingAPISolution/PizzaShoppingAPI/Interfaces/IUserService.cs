using PizzaShoppingAPI.Models.DTOs;
using PizzaShoppingAPI.Models;
namespace PizzaShoppingAPI.Interfaces
{
    public interface IUserService
    {
        public Task<LoginReturnDTO> Login(UserLoginDTO loginDTO);
        public Task<Customer> Register(CustomerUserDTO CustomerDTO);
    }
}
