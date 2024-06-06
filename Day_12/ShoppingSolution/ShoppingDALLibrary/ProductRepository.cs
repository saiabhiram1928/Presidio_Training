using ShoppingDALLibrary.Exceptions;
using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {

        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if(product !=null)
            {
                items.Remove(product);
            }
             return product;
        }
        public int GenId()
        {
            if (items.Count == 0) return 0;
            return items.Max((item) => item.Id);
        }
        public override Product GetByKey(int key)
        {
            Product product = items.FirstOrDefault((x) => x.Id == key);
            if (product == null)
            {
                throw new NoItemWithGiveIdException("product");
            }
            return product;


        }

        public override Product Update(Product item)
        {
            Product product = GetByKey(item.Id);
            if(product != null )
            {
                product = item;
            }
           
            return product;

        }
    }
}
