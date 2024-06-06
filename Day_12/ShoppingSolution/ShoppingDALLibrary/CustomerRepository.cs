using ShoppingDALLibrary.Exceptions;
using ShoppingModelLib;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int , Customer>
    {
        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }
        public int GenId()
        {
            if (items.Count == 0) return 0;
            return items.Max((item) => item.Id);
        }
        public override Customer GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoItemWithGiveIdException("Customer");
        }

        public override Customer Update(Customer item)
        {
            Customer customer = GetByKey(item.Id);
            if (customer != null)
            {
                customer = item;
            }
            return customer;
        }

    }
}
