namespace Task_1
{
    internal class Program
    {
        /// <summary>
        /// Takes Float input and Perform Validation
        /// </summary>
        /// <returns>Float</returns>
        float HandleFloatInput()
        {
            float num;
            while (float.TryParse(Console.ReadLine(), out num) == false && num < 0) 
            {
                Console.WriteLine("Please Enter a Valid number");
            };
            return num;
        }
        /// <summary>
        /// Takes Integer Input and Perfrom Validation
        /// </summary>
        /// <returns>Integer</returns>
        int HandleIntegerInput()
        {
            int num;
            while(int.TryParse(Console.ReadLine(),out num) == false)
            {
                Console.WriteLine("Please Enter a Valid Integer");
            }
            return num;
        }
        /// <summary>
        /// Print Diff Options Available 
        /// </summary>
        void PrintMenu()
        {
            Console.WriteLine("1. Company ABC");
            Console.WriteLine("2. Company Acceture");
            Console.WriteLine("0. Exit");
            return;

        }
        /// <summary>
        /// Print Employee Pf , Gf, Leave Details Based on the Company
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="employee"></param>
        void PrintEmployeeDetails(IGovtRules gr , Employee employee)
        {
            
            Console.WriteLine("--------*********-----------");
             
            Console.WriteLine($"The Employee Contribution to  Pension fund : {gr.EmployeePF(employee.BasicSalary)} \n Company Contribution to Pension Fund  : {employee.EmployerContributionToPf}");
            Console.WriteLine("--------******************---------");
            Console.WriteLine("Please Enter Service : ");
            float service = HandleFloatInput();
            Console.WriteLine($"Employee Gratuity amount : {gr.gratuityAmount(service, employee.BasicSalary)}");
            Console.WriteLine("--------******************---------");
            Console.WriteLine($"Leave Details for CTS is \n {gr.LeaveDetails()} ");
        }
        /// <summary>
        /// Hanldes Controller Logic for ABC Company
        /// </summary>
        void ABCCompanyHandler()
        {
            ABC employee = new ABC(101, "test1", "Technical", "Engineer", 1000.0);
            Console.WriteLine("---------------Employee Details-------------");
            Console.WriteLine(employee);
            PrintEmployeeDetails( employee ,employee );
           

        }
        /// <summary>
        /// Handles Controller Logic for XYZ Company
        /// </summary>
        void XYZCompanyHandler()
        {
            XYZ employee = new XYZ(1001, "XYZCompany1", "Sales", "Manager",1000000.0);
            Console.WriteLine("---------------Employee Details-------------");
            Console.WriteLine(employee);
            PrintEmployeeDetails(employee, employee); 
        }
        /// <summary>
        /// Prints InterActive Menu and Takes Choice Input and Handle Switch Statments
        /// </summary>
        void EmployeeInteraction()
        {
            int choice = 0;
            do {
                PrintMenu();
                Console.WriteLine("Please Enter Choice : ");
                choice = HandleIntegerInput();
                switch (choice)
                {
                    case 0: Console.WriteLine("_____End_____");break;

                    case 1: ABCCompanyHandler(); break;
                    case 2 : XYZCompanyHandler(); break;
                    
                    default : break;
                }

            } while (choice != 0);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.EmployeeInteraction();
            
        }
    }
}
