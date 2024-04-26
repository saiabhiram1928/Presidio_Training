using ShoppingDALLibrary.Exceptions;
using ShoppingModelLib;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class OrderRepository : AbstractRepository<int, Order>
    {
        public override Order Delete(int key)
        {
            Order order = GetByKey(key);
            if (order != null)
            {
                items.Remove(order);
            }
            return order;
        }
        public int GenId()
        {
            if (items.Count == 0) return 0;
            return items.Max((item) => item.Id);
        }
        public override Order GetByKey(int key)
        {
            Order order = items.FirstOrDefault((item) => item.Id == key);
            if (order == null)
            {
                throw new NoItemWithGiveIdException("Order");
            }
            return order;
        }
        public Order GetOrderByCustomerId(int customerId)
        {
            Order order = items.FirstOrDefault(item => item.Id == customerId);
             if(order == null)
            {
                throw new NoItemWithGiveIdException("order");
            }
             return order;
        }
        

        public override Order Update(Order item)
        {
            Order order = GetByKey(item.Id);
            if  (order != null)
            {
                order = item;
            }

            return order;
        }
    }
}
