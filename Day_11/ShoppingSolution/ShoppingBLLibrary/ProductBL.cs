using ShoppingDALLibrary;
using ShoppingDALLibrary.Exceptions;
using ShoppingModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
     public class ProductBL
    {
        
        ProductRepository productRepository;
        public ProductBL()
        {
            productRepository = new ProductRepository();
        }
        public Product AddProductToDb(double price, string name, int quantityInHand)
        {

            try
            {
                int id = productRepository.GenId() + 1;

                var product = productRepository.Add(new Product(id, price, name, quantityInHand));
                return product;
            } catch (DuplicateObjectException ex)
            {
                Console.WriteLine(ex.Message);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public List<Product> GetAllProducts()
        {
            var response = productRepository.GetAll();
            return response.ToList();
        }
         public Product GetProductById(int id)
        {
            try
            {
                var response = productRepository.GetByKey(id);
                return response;
            }catch(NoItemWithGiveIdException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
