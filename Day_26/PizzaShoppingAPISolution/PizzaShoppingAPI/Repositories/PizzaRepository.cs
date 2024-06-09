using PizzaShoppingAPI.Contexts;
using PizzaShoppingAPI.Exceptions;
using PizzaShoppingAPI.Interfaces;
using PizzaShoppingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PizzaShoppingAPI.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaShoppingContext _context;
        public PizzaRepository(PizzaShoppingContext context)
        {
            _context = context;
        }
        public async Task<Pizza> Add(Pizza item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Pizza> DeleteByKey(int key)
        {
            var Pizza = await GetByKey(key);
            if (Pizza != null)
            {
                _context.Remove(Pizza);
                _context.SaveChangesAsync(true);
                return Pizza;
            }
            throw new NoSuchPizzaException();
        }

        public Task<Pizza> GetByKey(int key)
        {
            var Pizza = _context.Pizzas.FirstOrDefaultAsync(e => e.Id == key);
            return Pizza;
        }

        public async Task<IEnumerable<Pizza>> Get()
        {
            var Pizzas = await _context.Pizzas.ToListAsync();
            return Pizzas;

        }

        public async Task<Pizza> Update(Pizza item)
        {
            var Pizza = await GetByKey(item.Id);
            if (Pizza != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return Pizza;
            }
            throw new NoSuchPizzaException();
        }
    }
}
