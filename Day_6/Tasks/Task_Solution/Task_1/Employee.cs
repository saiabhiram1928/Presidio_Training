using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Employee
    {
        /// <summary>
        /// Id of the Employee
        /// </summary>
        public int Empid { get; set; }
        /// <summary>
        /// Name of the Employee
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Department of the Employee
        /// </summary>
        public string Department { get; set; } = string.Empty;
        /// <summary>
        /// Designation of the Employee
        /// </summary>
        public string Designation { get; set; } = string.Empty;
        /// <summary>
        /// BasicSalary of the Employee
        /// </summary>
        public double BasicSalary { get; set; }
        /// <summary>
        /// Employer Contribution to PensionFund
        /// </summary>
        public double EmployerContributionToPf { get; protected set; }
        /// <summary>
        /// Default Constructor for Employee
        /// </summary>
       public Employee() 
        {
            Empid = 0;
            Name = string.Empty;
            Department = string.Empty;
            BasicSalary = 0;
            Department = string.Empty;
            BasicSalary = 0;
            EmployerContributionToPf = 0;
        }
        /// <summary>
        /// Caculate PensionFund for Employee and Employer
        /// </summary>
        /// <param name="BasicSalary"></param>
        /// <param name="PercentCut"></param>
        /// <returns>Double</returns>
        protected double CalculatePfs(double BasicSalary, double PercentCut)
        {
            return (BasicSalary * PercentCut) / (100);
        }
        /// <summary>
        /// Parameterized Constructor for Class Employee
        /// </summary>
        /// <param name="empid"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="designation"></param>
        /// <param name="basicSalary"></param>
        public Employee(int empid, string name, string department, string designation, double basicSalary)
        {
            Empid = empid;
            Name = name;
            Department = department;
            Designation = designation;
            BasicSalary = basicSalary;
        }
        /// <summary>
        /// Print Employee Details 
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return $" EmployeeId : ${Empid}\n Name: {Name}\n Department : {Department}\n Designation : {Designation}\n BasicSalary : {BasicSalary}";
        }
    }
}
