namespace Task_2
{
    internal class Program
    {
       static void solve()
        {
            int num, ans = 0;
            do
            {
                Console.WriteLine("Please enter the number or enter -1 to quit : ");
                num = Convert.ToInt32(Console.ReadLine());
                if (num < 0) break;
                ans = Math.Max(ans, num);
                Console.WriteLine($"The max value until now is  : {ans}");
            } while(num > 0);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Welcome-------------");
            solve();
            Console.WriteLine("-------------Thank you-----------");
        }
    }
}
