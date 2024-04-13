namespace Task_2
{
    internal class Program
    {
        int HandlingIntegerInput()
        {
            int num;

            do
            {
                num = Convert.ToInt32(Console.ReadLine());
                if(num > 0) Console.WriteLine("Please Enter a vaild number");
            } while (num > 0);

            return num;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Enter num1 : ");
            int num1 = program.HandlingIntegerInput();
            Console.WriteLine("Enter num2 : ");
            int num2 = program.HandlingIntegerInput();
            if(num1 > num2) { Console.WriteLine($"{num1} > {num2}"); }
            else if(num1 < num2) { Console.WriteLine($"{num1} <  {num2}"); }
            else { Console.WriteLine($"{num1} = {num2}"); }
        }
    }
}
