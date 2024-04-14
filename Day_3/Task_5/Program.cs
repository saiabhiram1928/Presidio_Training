using System.ComponentModel.DataAnnotations;

namespace task_4
{
    internal class Program
    {
        string HandleStringInput()
        {
            string? str = string.Empty;
            do
            {
                str = Console.ReadLine();
                if(string.IsNullOrEmpty(str))
                {
                    Console.WriteLine("Please Enter a valid string");
                }
            }while (string.IsNullOrWhiteSpace(str));
            return str;
        }
        bool Validation(string username, string password)
        {
            if(username == "ABC" && password == "123") return true;
            return false;
        }
        void TakingInputThreeTimes()
        {
            int counter = 1;
            while(counter <=4) 
            {
               
                if(counter == 4) { Console.WriteLine("You have Exceeded Number of attempts"); break;  }
                Console.WriteLine("Please Enter username : ");
                string username = HandleStringInput();
                Console.WriteLine("Please Enter password : ");
                string password = HandleStringInput();
                if(Validation(username , password))
                {
                    Console.WriteLine("You have sucessfully logged in");
                }
                else
                {
                    Console.WriteLine("Incorrect username or password");
                }
                counter++;
            }
        }
        static void Main(string[] args)
        {
          Program program = new Program();
          program.TakingInputThreeTimes();
            
        }
    }
}
