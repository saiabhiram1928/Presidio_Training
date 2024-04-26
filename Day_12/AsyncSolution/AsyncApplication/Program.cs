namespace AsyncApplication
{
    namespace AsyncApplication
    {
        internal class Program
        {
            async Task<int> GetResultFromDatabaseServer()
            {
               // Simulating server delay
                return new Random().Next();
            }

            static async Task Main(string[] args)
            {
                Console.WriteLine("Hello, World!");
                Program program = new Program();

                // Start fetching the result from the server asynchronously
                Task<int> serverTask = program.GetResultFromDatabaseServer();

                // Generate the second random number directly
                var number1 = new Random().Next();
                Console.WriteLine("This is the random number from main: " + number1);

                // Now, await the result from the server
                var number2 = await serverTask;
                Console.WriteLine("This is the random number from server: " + number2);
            }
        }
    }

}
