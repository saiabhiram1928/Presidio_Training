using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReqTrackerModellib
{
    public class ContractEmployee : Employee
    {
        public double WagesPerDay { get; set; }
        public ContractEmployee() 
        {
            Type = "ContractEmployee";
            WagesPerDay = 0.0;
        }
        public ContractEmployee(int id, string name, DateTime dateOfBirth, double wagesPerDay) : base(id, name, dateOfBirth)
        {
            Type = "ContractEmployee";
            Console.WriteLine("Contract Employee class prameterized constructor");
            WagesPerDay = wagesPerDay;
            Salary = CalculateSalary();
        }
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            Console.WriteLine("Please enter the Wages");
            WagesPerDay = Convert.ToDouble(Console.ReadLine());
            Salary = CalculateSalary();
        }
        double CalculateSalary()
        {
            return WagesPerDay * 30;
        }
    }
}
