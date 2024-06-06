using ShoppingDALLibrary;
using ShoppingDALLibrary.Exceptions;
using ShoppingModelLib;
using System.Net.Http.Headers;

namespace ShoppingBLLibrary
{
    public class CustomerBL
    {
        CustomerRepository customerRepository;
        public CustomerBL()
        {
            customerRepository = new CustomerRepository();
        }
        public Customer AddCustomerToDb(string name,string phone)
        {
            Console.WriteLine("Hii customer");
            try
            {
                int id = customerRepository.GenId() + 1;
                Console.WriteLine($"id : {id}");
                var response = customerRepository.Add(new Customer(id,name,phone));
                return response;
            }catch (DuplicateObjectException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public Customer GetCustomerById(int id)
        {
            try
            {
                var response = customerRepository.GetByKey(id);
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
