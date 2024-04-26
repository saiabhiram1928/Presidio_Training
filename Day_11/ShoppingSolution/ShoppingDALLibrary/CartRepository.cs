using ShoppingDALLibrary.Exceptions;
using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override Cart Delete(int key)
        {
            Cart cart = GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }
        public int GenId()
        {
            if (items.Count == 0) return 0;
            return items.Max((item) => item.Id);
        }
        public override Cart GetByKey(int key)
        {
           Cart cart = items.FirstOrDefault(item => item.Id == key);
            if(cart == null)
            {
                throw new NoItemWithGiveIdException("Cart");
            }
            return cart;
        }
      
        public override Cart Update(Cart item)
        {
            Cart cart = GetByKey(item.Id);
            if (cart != null)
            {
                cart = item;
            }
            return cart;
        }
        
        public Cart GetCartByCustomerId(int customerId)
        {
            Cart cart = items.FirstOrDefault((item) => item.CustomerId == customerId);
            if( cart == null ) 
            {
                throw new NoItemWithGiveIdException("Cart (with customerID)");
            }
            return cart;
        }
    }
}
