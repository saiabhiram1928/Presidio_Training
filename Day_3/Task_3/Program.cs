namespace Task_3
{
    internal class Program
    {
        static float Average()
        {
            int num = 0, sum = 0, count = 0;
            do
            {
                Console.WriteLine("Enter the number (or) Enter -1 to get the average : ");
                num = Convert.ToInt32(Console.ReadLine());
                if (num < 0) break;
                if(num % 7 == 0)
                {
                    sum += num;
                    count++;
                }
            } while (num > 0);
            if (num < 0 && sum == 0 && count == 0) return -1;
            return (float)sum / (float) count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("----------Welcome--------------");
          float avg = Average();
            if(avg > 0) 
                 Console.WriteLine($"The average of numbers divided by 7 for the given numbers is : {avg}");
        }
    }
}
