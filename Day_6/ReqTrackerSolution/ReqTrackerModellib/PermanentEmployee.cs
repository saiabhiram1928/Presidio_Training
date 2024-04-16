using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqTrackerModellib
{
    public class PermanentEmployee : Employee
    {
        public PermanentEmployee() 
        {
            Type = "Permanent Employee";
        }
        public PermanentEmployee(int id, string name, DateTime dateOfBirth, double salary) : base(id, name, dateOfBirth)
        {
            Type = "ContractEmployee";
            Salary = salary;
        }
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            Console.WriteLine("Please enter the Salary : ");
            Salary = Convert.ToDouble(Console.ReadLine());
        }

    }
}
