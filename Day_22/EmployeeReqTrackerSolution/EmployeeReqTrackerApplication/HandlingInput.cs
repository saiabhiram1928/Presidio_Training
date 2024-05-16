using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerApplication
{
    internal class HandlingInput
    {
       public int HandlingIntegerInput()
        {
            int num;
            while (int.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("**Please Enter a Vaild Intger**");
            }
            return num;
        }
       public float HandlingFloatInput()
        {
            float num;
            while (float.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("**Please Enter a Vaild Decimal**");
            }
            return num;
        }
       public string HandlingPhoneNumber()
        {
            string str = string.Empty;
            do
            {
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Please Enter a Valid Phone Number");
                }
            } while (string.IsNullOrEmpty(str) || str.Length != 10);
            return str;
        }
      public string HandlingStringInput(string Msg)
        {
            string? str = string.Empty;
            do
            {
                str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                {
                    Console.WriteLine(Msg);
                }
            } while (string.IsNullOrEmpty(str));
            return str;
        }
    }
}
