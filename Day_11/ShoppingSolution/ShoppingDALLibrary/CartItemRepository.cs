using ShoppingDALLibrary.Exceptions;
using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository
    {
        readonly List<CartItems> items;
        
        public CartItemRepository()
        {
            items = new List<CartItems>();
        }
        public CartItems GetByKey(int productId, int cartId)
        {
            CartItems item = items.FirstOrDefault((x) => x.ProductId == productId && x.CartId == cartId );
            if(item == null)
            {
                throw new NoItemWithGiveIdException("CartItem");
            }
            return item;
        }
        public CartItems Update(CartItems item)
        {
            CartItems Cartitem = GetByKey(item.ProductId, item.CartId);
            if(item != null)
            {
                Cartitem = item;
            }
            return Cartitem; 
        }

    }
}
