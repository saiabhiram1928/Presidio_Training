using ReqTrackerModellib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    internal interface IEmployeeService
    {
        int AddEmployee(Employee employee);
        Employee ChangeEmployeeName(string employeeNewName, int id);
        Employee GetEmployeeById(int id);
        string GetDepartmentByEmployeeName(string employeeName);
    }
}
