using Microsoft.EntityFrameworkCore;
using PizzaShoppingAPI.Models;
namespace PizzaShoppingAPI.Contexts
{
    public class PizzaShoppingContext : DbContext
    {
        public PizzaShoppingContext(DbContextOptions<PizzaShoppingContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 101,
                    Name = "Margherita",
                    Price = 150,
                    InStock = true
                
                },
                new Pizza
                {
                    Id = 102,
                    Name = "Pepperoni",
                    Price = 170,
                    InStock = true
                  
                },
                new Pizza
                {
                    Id = 103,
                    Name = "Capsicum Veg",
                    Price = 180,
                    InStock = true

                }
            );

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Pizzas)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Customer)
                .WithOne()
                .HasForeignKey<User>(u => u.CustomerId);

            base.OnModelCreating(modelBuilder);
        }

    }
    
}
