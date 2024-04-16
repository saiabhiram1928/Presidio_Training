using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class ABC : Employee,GovtRules
    {
    
        /// <summary>
        /// Defaulf Constructor For ABC Class
        /// </summary>
        public ABC() 
        {
            EmployerContributionToPf = 0;
        }
       /// <summary>
       /// Parameterized Contructor For ABC 
       /// </summary>
       /// <param name="empid"></param>
       /// <param name="name"></param>
       /// <param name="department"></param>
       /// <param name="designation"></param>
       /// <param name="basicSalary"></param>
        public ABC(int empid, string name, string department, string designation, double basicSalary ) :base(empid , name , department, designation, basicSalary)
        {
            EmployerContributionToPf = CalculatePfs(basicSalary, 8.33);
        }
        
      
        /// <summary>
        /// Implements EmployeePf Method And Returns Employee Contribution to Pf
        /// </summary>
        /// <param name="basicSalary"></param>
        /// <returns>Double</returns>
        public double EmployeePF(double basicSalary)
        {
            return CalculatePfs(basicSalary, 3.67);
        }
        /// <summary>
        /// Implements gratuityAmount Method and return gratuityAmount of the employee
        /// </summary>
        /// <param name="serviceCompleted">Serive Period</param>
        /// <param name="basicSalary"></param>
        /// <returns>Double</returns>
        public double gratuityAmount(float serviceCompleted, double basicSalary)
        {
            if(serviceCompleted < 5) return 0 ;
            else if(serviceCompleted > 5 && serviceCompleted <= 10) return basicSalary ;
            else if(serviceCompleted > 10 && serviceCompleted <= 20) return 2*basicSalary ;
            return 3*basicSalary;
        }
        /// <summary>
        /// Prints Leave Details of the Company
        /// </summary>
        /// <returns>String</returns>
        public string LeaveDetails()
        {
            return "1) 1 day of Casual Leave per month \n 2) 12 days of Sick Leave per year \n 3) 10 days of Privilege Leave per year\n";
        }
    }
}
