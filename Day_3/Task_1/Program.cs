namespace Task_1
{
    internal class Program
    {
        /// <summary>
        /// Handles integer input with exception
        /// </summary>
        /// <returns>Integer</returns>
        int HandlingIntegerInput()
        {
            int num;
            while(int.TryParse(Console.ReadLine(), out num) == false )
            {
                Console.WriteLine("Please Enter a valid number");
            }          
            return num;
        }
        /// <summary>
        /// Takes two numbers and adds them
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Integer</returns>
        int Add(int num1, int num2)
        {
            return num1 + num2;
        }
        /// <summary>
        /// Multiples the give two numbers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Integer</returns>
        int Mul(int num1 , int num2) 
        {
            return num1 * num2;
        }

        /// <summary>
        /// Subtracts second number from first number
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Interger</returns>
        int Subtract(int num1, int num2)
        {
            return num1 - num2;
        }
        /// <summary>
        /// Divides first number with second number
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Integer</returns>
        int Division(int num1, int num2)
        {
            return num1 / num2;
        }
        /// <summary>
        /// Gives Remainder of two numbers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>Integer</returns>
        int Rem(int num1, int num2)
        {
            return num1 % num2;
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Enter first number : ");
            int num1 = program.HandlingIntegerInput();
            Console.WriteLine("Enter second number : ");
            int num2 = program.HandlingIntegerInput();
            Console.WriteLine($"{num1} + {num2}  = " + program.Add(num1,num2));
            Console.WriteLine($"{num1} * {num2}  = " + program.Mul(num1,num2));
            Console.WriteLine($"{num1} / {num2}  = " + program.Division(num1,num2));
            Console.WriteLine($"{num1} - {num2}  = " + program.Subtract(num1,num2));
            Console.WriteLine($"{num1} % {num2}  = " + program.Rem(num1,num2));


        }
    }
}
