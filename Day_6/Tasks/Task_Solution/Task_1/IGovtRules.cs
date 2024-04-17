using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    /// <summary>
    /// Interface Contains EmployeePf , LeaveDetails, GratuityAmount methods
    /// </summary>
    public interface IGovtRules
    {
        public double EmployeePF(double basicSalary);
        public string LeaveDetails();
        public double gratuityAmount(float serviceCompleted, double basicSalary);

    }
}
