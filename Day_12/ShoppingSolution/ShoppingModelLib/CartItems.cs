using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLib
{
    public class CartItems
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public CartItems(int cartId, int productId, Product product, int quantity, double price, double discount)
        {
            CartId = cartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;
            Price = price;
            Discount = discount;
        }

        public override string ToString()
        {
            return $"Cart Id: {CartId} \n qunatity : {Quantity} \n price : {Price} \n product id : { ProductId}";
        }

    }
}
