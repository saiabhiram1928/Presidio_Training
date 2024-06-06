using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApplication
{
    public class InputValidation
    {
        public int HandlingIntegerInput()
        {
            int num; 
            while(int.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("\t Please Enter a Valid Integer");
            }
            return num;
        } 
        public double HandlingDoubleInput()
        {
            double num; 
            while(double.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("\t Please Enter a Valid Number");
            }
            return num;
        }
        public  string HandlingStringInput()
        {
            string? str = string.Empty;
            do
            {
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("\t Please Enter a Valid String");
                }
            } while (string.IsNullOrEmpty(str));
            return str;
        }
        public string HandlingPhonenumberInput()
        {
            string phonenumber = string.Empty;
            do
            {
                phonenumber = Console.ReadLine();

                if (!IsValidPhoneNumber(phonenumber))
                {
                    Console.WriteLine("\t Please enter a valid phone number with 10 digits.");
                }
            } while (!IsValidPhoneNumber(phonenumber));

            return phonenumber;
        }

        private static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length != 10)
            {
                return false;
            }

            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
