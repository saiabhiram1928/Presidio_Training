using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class XYZ : Employee, IGovtRules
    {
        /// <summary>
        /// Default Constructor of Class XYZ
        /// </summary>
        public XYZ() 
        {
            EmployerContributionToPf = 0;
        }
        /// <summary>
        /// Parameterized Constructor Class XYZ
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="designation"></param>
        /// <param name="basicSalary"></param>
        public XYZ(int empid, string name, string department, string designation, double basicSalary) : base(empid, name, department, designation, basicSalary)
        {
            EmployerContributionToPf = CalculatePfs(basicSalary, 12);
        }
        /// <summary>
        /// Print Employee De
        /// </summary>
        /// <returns></returns>
       
        public double EmployeePF(double basicSalary)
        {
            return CalculatePfs(basicSalary, 0);
        }

        public double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            return 0;
        }

        public string LeaveDetails()
        {
            return "1) 2 day of Casual Leave per month \n 2) 5 days of Sick Leave per year \n 3) 5 days of Previlage Leave per year\n";
        }
    }
}
