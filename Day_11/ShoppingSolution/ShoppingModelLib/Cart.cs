using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 

        public List<CartItems> CartItems { get; set; }
        public Cart()
        {
            Id = 0;
            CustomerId = 0;
            Customer = new Customer();
            CartItems = new List<CartItems>();
        }
       
        public Cart(int id, int customerId, Customer customer, List<CartItems> cartItems)
        {
            Id = id;
            CustomerId = customerId;
            Customer = customer;
            CartItems = cartItems;
        }
    }
}
