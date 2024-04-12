namespace Taks_2
{
    internal class Program
    {
        /// <summary>
        /// Handle the String input and Perform Validation
        /// </summary>
        /// <returns>String</returns>
        string HandlingStringInput()
        {
            string? str;
            do
            {
                str = Console.ReadLine();
                if(str?.Length != 16 || string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Please Enter a Valid Card Number");
                }
            } while (string.IsNullOrEmpty(str) || str?.Length != 16);
            return str;
        }
        /// <summary>
        /// Contains the Controller logic for CardNumber
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool check(string str)
        {
            string ReverseStr = new string(str.Reverse().ToArray());
            int sum = 0;
            for(int i = 0; i < ReverseStr.Length; i++)
            {
                if((i+1) % 2 == 0)
                {
                    int temp = ((int)ReverseStr[i] - 48);
                    temp = temp * 2;
                    sum += (temp % 10) + (temp / 10);

                }
                else
                {
                    sum+= ((int)ReverseStr[i]-48);
                }
            }
            return sum%10 == 0;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Please Enter Card Details (size of card should be 16) : ");
            string CardNumber = program.HandlingStringInput();
            if(check(CardNumber) )
            {
                Console.WriteLine("The Card is Valid");
            }
            else
            {
                Console.WriteLine("The Card is Invalid");
            }

        }
    }
}
