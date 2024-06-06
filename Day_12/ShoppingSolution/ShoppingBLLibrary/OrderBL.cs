using ShoppingDALLibrary;
using ShoppingDALLibrary.Exceptions;
using ShoppingModelLib;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class OrderBL
    {
        OrderRepository orderRepository;
        CartRepository cartRepository;
        public OrderBL()
        {
            orderRepository = new OrderRepository();
            cartRepository = new CartRepository();
        }
        double CalculateTotalAmount(Cart cart)
        {
            double sum = 0;
            for(int i =0; i<cart.CartItems.Count; i++) 
            {
                sum += (cart.CartItems[i].Quantity * cart.CartItems[i].Price);
            }
            return sum;
        }
        public Order CreatingOrder(int customerId, string address, int pincode, string phoneNumber, string paymentMethod)
        {
            Cart cart = null;
            try
            {
                cart = cartRepository.GetCartByCustomerId(customerId);
                if (cart.CartItems.Count < 0)
                {
                    return null;
                }
                int id = orderRepository.GenId()+1;
                double totalAmount = CalculateTotalAmount(cart);
                Order order = new Order(id, cart.Id, address, pincode, phoneNumber, paymentMethod, totalAmount, customerId);
                return order;
            } catch (NoItemWithGiveIdException ex)
            {
                Console.WriteLine(ex.Message);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public List<Order> GetAllOrdersOfUser(int customerId)
        {
            List<Order> orders = null;
            try
            {
                orders = orderRepository.GetAll().Where((item) => item.CustomerId == customerId).ToList();
                return orders;
            }
            catch(NoItemWithGiveIdException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return orders;
        }

    }

}
