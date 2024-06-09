using PizzaShoppingAPI.Interfaces;
using PizzaShoppingAPI.Models;
using Microsoft.EntityFrameworkCore;
using PizzaShoppingAPI.Contexts;
using PizzaShoppingAPI.Exceptions;

namespace PizzaShoppingAPI.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly PizzaShoppingContext _context;

        public UserRepository(PizzaShoppingContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            item.Status = "Disabled";
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> DeleteByKey(int key)
        {
            var user = await GetByKey(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new NoSuchUserException("No user with the given ID");
        }

        public async Task<User> GetByKey(int key)
        {
            return (await _context.Users.SingleOrDefaultAsync(u => u.CustomerId == key)) ?? throw new Exception("No user with the given ID");
        }

        public async Task<IEnumerable<User>> Get()
        {
            return (await _context.Users.ToListAsync());
        }

        public async Task<User> Update(User item)
        {
            var user = await GetByKey(item.CustomerId);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new NoSuchUserException("No user with the given ID");
        }
    }
}
