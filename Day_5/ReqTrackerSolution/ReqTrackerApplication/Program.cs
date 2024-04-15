using ReqTrackerModellib;
using System.Xml.Linq;

namespace ReqTrackerApplication
{
    internal class Program
    {
        void UnderstandingSqueceExecution()
        {
            Console.WriteLine("Helloo Welcome");
            Console.WriteLine("my name is C#");
            int num1 =1, num2 =2;
            Console.WriteLine($"{num1} + {num2} = {num1+num2}");
        }
        void UndersttandingCondtionlStatement()
        {
            string str = "ramu";
            if(str  == "ramu") Console.WriteLine("Hii Ramu");
            else if(str == "somu") Console.WriteLine("Hii Somu");
            else Console.WriteLine("Hiii unknown");
        }
        void UnderstandingSwitchCase()
        {
            string str = "ramu";
            switch(str)
            {
                case "ramu":
                    Console.WriteLine("Hii ramu");
                    break;
                case "somu":
                    Console.WriteLine("Hii somu");
                    break;
                default:
                    Console.WriteLine("Hii unknown");
                    break;
            }
        }
        bool PerformValidation(int num)
        {
            int prev = num % 10;
            num /= 10;
            while(num > 0)
            {
                int digit = num % 10;
                if (prev != digit) return false;
                prev = digit;
                num /= 10;
            }
            return  true;

        }
        void UnderStandingArrays()
        {
            int[] arr = { 666, 777, 121 , 111 ,100 } ;
            int ans = 0;
            for(int i =0; i<arr.Length ; i++)
            {
                if (PerformValidation(arr[i])) ans += 1;
            }
            Console.WriteLine("The count of number having same digtis is  : " + ans);
        }
        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("0. Exit");
        }
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }
        void PrintAllEmployees()
        {
            if (employees[employees.Length-1] == null)
            {
                Console.WriteLine("No Employees available");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                    PrintEmployee(employees[i]);
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }
        int HandlingIntegerInput()
        {
            int num = 0;
            while (int.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("Please Enter a valid number \n");
            }
            return num;

        }
        string HandlingStringInput()
        {
            return Console.ReadLine() ?? String.Empty;
        }
        int GetIdFromConsole()
        {
            return HandlingIntegerInput();
        }
        void GetEmployeeByIdAndUpdate(int id)
        {
             
            for(int i =0;i<employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    Console.WriteLine("Please Enter Updated Name : ");
                    employees[i].Name = HandlingStringInput();
                    PrintEmployee(employees[i]);
                    return;
                }
            }
            Console.WriteLine("There is no such employee with given id");
            return;
        }
        void UpdateEmployee()
        {
            int id;
            if (employees[0] == null)
            {
                Console.WriteLine("No Employee Available");
                return;
            }
            Console.WriteLine("Please Enter Id of the employee to be updated : ");
            id = GetIdFromConsole();
             GetEmployeeByIdAndUpdate(id);
            return;
        }
        void GetEmployeeByIdAndDelete(int id)
        {

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i]  = null;
                    return;
                }
            }
            Console.WriteLine("There is no such employee with given id");
            return;
        }
        void DeleteEmployee()
        {
            int id;
            if (employees[0] == null)
            {
                Console.WriteLine("No Employee Available");
                return;
            }
            Console.WriteLine("Please Enter Id of the employee to be deleted : ");
            id = GetIdFromConsole();
            GetEmployeeByIdAndDelete(id);
            PrintAllEmployees();
            return;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.UnderstandingSqueceExecution();
            //program.UndersttandingCondtionlStatement();
            //program.UnderstandingSwitchCase();
            //program.UnderStandingArrays();
            program.EmployeeInteraction();
        }
    }
}
