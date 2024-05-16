using EmployeeReqTrackerBLLibrary;
using EmployeeReqTrackerModelLibrary;
namespace EmployeeReqTrackerApplication
{
    
    internal class Program
    {
        bool Islogin = false;
        Employee employee;
        HandlingInput inputhandler = new HandlingInput();
        EmployeeLoginBL employeeLogin = new EmployeeLoginBL();

        void PrintMenu()
        {
            Console.WriteLine("-------------Employee Request Tracker-------------");
            if (Islogin == false)
            {
                Console.WriteLine("11) Login");
                Console.WriteLine("12) Login");
            }
        }
         async Task HandleLoginProcess()
        {
            if (Islogin == true)
            {
                await Console.Out.WriteLineAsync("User Already Loggged In");
                return;
            }

            Console.WriteLine("Enter Id of the Employee : ");
            int id = inputhandler.HandlingIntegerInput();
            Console.WriteLine("Enter Password : ");
            string password = inputhandler.HandlingStringInput("Enter a Valid Password");
            try
            {
               Employee emp =  new Employee() { Password = password , Id = id };
                var res = await employeeLogin.Login(emp);
                if(res == false)
                {
                    await Console.Out.WriteLineAsync("username or password are wrong");
                    return;
                }
                await Console.Out.WriteLineAsync("Login Sucess");
                Islogin = true;
                employee = emp;
                return;
            }catch (NullReferenceException ex)
            {
                await Console.Out.WriteLineAsync($"{ex.Message}");
            }
           
        }
        async Task HandleRegisterProcess()
        {
            if (Islogin == true)
            {
                await Console.Out.WriteLineAsync("User Already Loggged In");
                return;
            }
            await Console.Out.WriteLineAsync("Please Enter your Name");
            string name = inputhandler.HandlingStringInput("Enter a Valid Name");
            await Console.Out.WriteLineAsync("Please Enter your password");
            string password = inputhandler.HandlingStringInput("Enter a Valid Password");
            var emp =  new Employee() { Name = name, Password = password };
            var res = await employeeLogin.Register(emp);
             Console.WriteLine(res);


        }
        
        async void Menu()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please Enter the Choice");
                choice = inputhandler.HandlingIntegerInput();

                switch (choice)
                {
                    case 11:
                        await HandleLoginProcess();
                        break;
                    case 12:
                        await HandleRegisterProcess();
                        break;
                    default:
                        Console.WriteLine("-----Bye---------"); 
                        break;
                }

            } while (choice != 0);
        }
        static void Main(string[] args)
        {
            new Program().Menu();
        }
    }
}
