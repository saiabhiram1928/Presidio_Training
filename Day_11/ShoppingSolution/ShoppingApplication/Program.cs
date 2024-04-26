using ShoppingBLLibrary;
using ShoppingModelLib;
using System.Security.Cryptography.X509Certificates;

namespace ShoppingApplication
{
    internal class Program
    {
        CustomerBL customerMethods = new CustomerBL();
        OrderBL orderMethods = new OrderBL();
        ProductBL productMethods = new ProductBL();
        CartBL cartMethods = new CartBL();
        InputValidation inputValidation = new InputValidation();
        Customer user = null;
        void AddProducts()
        {
            Console.WriteLine("Please Enter Name of the Product");
            string name = inputValidation.HandlingStringInput();
            Console.WriteLine("Please Enter Price of the Product");
            double price = inputValidation.HandlingDoubleInput();
            Console.WriteLine("Enter Qunatity in Hand : ");
            int quantity = inputValidation.HandlingIntegerInput();
            var response = productMethods.AddProductToDb(price, name, quantity);
            if(response == null)
            {
                Console.WriteLine("There is a Problem Adding the product");
                return;
            }
            Console.WriteLine("Product Added Sucessfully");
            return;

        }
        void AddUsers()
        {
            Console.WriteLine("Please Enter Name of the customer");
            string name = inputValidation.HandlingStringInput();
            Console.WriteLine("Please Enter Phone number : ");
             string phoneNumber = inputValidation.HandlingPhonenumberInput();
            var response = customerMethods.AddCustomerToDb(name, phoneNumber);
            Console.WriteLine(response+"respone");
            if (response == null)
            {
                Console.WriteLine("There is a Problem While adding User");
            }
            Console.WriteLine("User Created Sucessfully");
        }
        void ShowAllProducts()
        {
            var response = productMethods.GetAllProducts();
            if(response == null) { Console.WriteLine("There are no products in db"); return; }
            for(int i = 0; i < response.Count; i++)
            {
                Console.WriteLine(response[i]);
            }
            return;
        }
       void AddItemToCart()
        {
            Console.WriteLine("Enter User Id :");
            int customerid = inputValidation.HandlingIntegerInput();
            Customer customer = customerMethods.GetCustomerById(customerid);
            if(customer == null) { return; }
            Console.WriteLine("Please Enter product Id");
            int productid = inputValidation.HandlingIntegerInput();
            Product product = productMethods.GetProductById(productid);
            if (product == null) return;
            Console.WriteLine("Enter Qunatity ");
            int quantity = inputValidation.HandlingIntegerInput();
            var response = cartMethods.AddItemsToCart(customer, product, quantity);
            if(response == null) { Console.WriteLine("Please try again");return; }
            Console.WriteLine("Sucesffully Added");
            return;
        }
        void ShowCartItems()
        {
            Console.WriteLine("Enter Customer Id");
            int id = inputValidation.HandlingIntegerInput();
            var response = cartMethods.GetAllCartItems(id);
            if(response == null) { Console.WriteLine("No customer With id"); return; }
            for(int i = 0; i< response.Count; i++)
            {
                Console.WriteLine(response[i]);
            }
            return;
        }
        void PrintMenu()
        {
            Console.WriteLine("11) Add Products");
            Console.WriteLine("12) Show All Products");
            Console.WriteLine("21) Add Users");
            Console.WriteLine("31) Add to Cart");
            Console.WriteLine("32) Show Cart Item");
            Console.WriteLine("41) Order");
        }
        void Menu()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please Enter a Choice");
                choice = inputValidation.HandlingIntegerInput();
                switch (choice)
                {
                    case 11:
                        AddProducts();
                        break;
                    case 12:
                        ShowAllProducts();
                        break;
                    case 21:
                        AddUsers();
                        break;
                    case 31:
                        AddItemToCart();
                        break;
                    case 32:
                        ShowCartItems();
                        break;
                    default:
                        break;
                }
            }while (choice != 0);
        }
        static void Main(string[] args)
        {
            new Program().Menu();   
        }
    }
}
