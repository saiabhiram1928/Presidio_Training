using ShoppingDALLibrary;
using ShoppingDALLibrary.Exceptions;
using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL
    {
        readonly CartRepository cartRepository;
        readonly CartItemRepository cartItemRepository;

        public CartBL()
        {
            cartRepository = new CartRepository();
            cartItemRepository = new CartItemRepository();
        }
        void AddExisitinItemToCart(CartItems existingItem , int quantity)
        {
            existingItem.Quantity += quantity;
            cartItemRepository.Update(existingItem);
        }
        void AddNewItemToCart(Cart cart , Product product , int quantity)
        {
            CartItems newItem = new CartItems
            (
                 cart.Id,
                 product.Id,
                 product,
                 quantity,
                product.Price,
                 0
            );
                
            cart.CartItems.Add(newItem);
            cartItemRepository.Update(newItem);
        }
        public List<CartItems> AddItemsToCart(Customer customer , Product product, int qunatity)
        {
            Cart cart = null;
            try
            {
                 cart = cartRepository.GetCartByCustomerId(customer.Id);
            }
            catch(NoItemWithGiveIdException ex) 
            {
                Console.WriteLine(ex.Message);
                int id = cartRepository.GenId() + 1;
                cart = new Cart { Id = id, CustomerId = customer.Id, CartItems = new List<CartItems>() };
                cartRepository.Add(cart);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); return null; }
            CartItems existingItem = cart.CartItems.FirstOrDefault(item => item.ProductId == product.Id);
            if (existingItem != null) { AddExisitinItemToCart(existingItem , qunatity); }
            else AddNewItemToCart(cart, product ,qunatity);
            return cart.CartItems.ToList();
        }
        public List<CartItems> RemoveItemsFromCart(Customer customer, CartItems cartitem)
        {
            Cart cart = null;
            try
            {
                cart = cartRepository.GetCartByCustomerId(customer.Id);
                cart.CartItems.Remove(cartitem);
            }
            catch (NoItemWithGiveIdException ex) { Console.WriteLine(ex.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
            return cart?.CartItems.ToList();
        }
        public List<CartItems> GetAllCartItems(int customerId)
        {
            Cart cart = null;
            try
            {
                cart = cartRepository.GetCartByCustomerId(customerId);

            }catch(NoItemWithGiveIdException ex)
            {
                Console.WriteLine(ex.Message);
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
            return cart.CartItems.ToList();    
        }
    }
}
