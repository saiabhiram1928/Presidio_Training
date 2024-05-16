using EmployeeReqTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerBLLibrary
{
    public interface IEmployeeLoginBL
    {
        public Task<bool> Login(Employee employee);
        public Task<Employee> Register(Employee employee);
    }
}
