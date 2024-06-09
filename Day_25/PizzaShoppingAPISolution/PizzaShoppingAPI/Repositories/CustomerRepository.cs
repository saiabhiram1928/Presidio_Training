using PizzaShoppingAPI.Interfaces;
using PizzaShoppingAPI.Models;
using PizzaShoppingAPI.Exceptions;
using Microsoft.EntityFrameworkCore;
using PizzaShoppingAPI.Contexts;

namespace PizzaShoppingAPI.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly PizzaShoppingContext _context;
        public CustomerRepository(PizzaShoppingContext context)
        {
            _context = context;
        }
        public async Task<Customer> Add(Customer item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Customer> DeleteByKey(int key)
        {
            var Customer = await GetByKey(key);
            if (Customer != null)
            {
                _context.Remove(Customer);
                _context.SaveChangesAsync(true);
                return Customer;
            }
            throw new NoSuchCustomerException();
        }

        public Task<Customer> GetByKey(int key)
        {
            var Customer = _context.Customers.FirstOrDefaultAsync(e => e.Id == key);
            return Customer;
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            var Customers = await _context.Customers.ToListAsync();
            return Customers;

        }

        public async Task<Customer> Update(Customer item)
        {
            var Customer = await GetByKey(item.Id);
            if (Customer != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return Customer;
            }
            throw new NoSuchCustomerException();
        }
    }
}
