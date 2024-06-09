using PizzaShoppingAPI.Interfaces;
using PizzaShoppingAPI.Models;

namespace PizzaShoppingAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<int, Customer> _repository;

        public CustomerService(IRepository<int, Customer> repository)
        {
            _repository = repository;
        }
    }
}
