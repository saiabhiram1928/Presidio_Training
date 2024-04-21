using ReqTrackerModellib;
using RequestTrackerDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{

    public class EmployeeBL : IEmployeeService
    {
        readonly IRepository<int, Employee> _employeeRepository;
        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }
        void ThrowingNullExeception(string text)
        {
            throw new NullReferenceException($"The Employee with given {text} doesn't exist");
        }

        public int AddEmployee(Employee department)
        {
            var res = _employeeRepository.Add(department);
            if (res == null)
            {
                throw new DuplicateObjectException("The Department Already Existed");
            }
            return department.Id;

        }
        public Employee ChangeEmployeeName(string employeeNewName, int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null) ThrowingNullExeception("id");
            employee.Name = employeeNewName;
            return _employeeRepository.Update(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null) ThrowingNullExeception("id");
            return employee;
        }

        public string GetDepartmentByEmployeeName(string employeeName)
        {
           var employees = _employeeRepository.GetAll();
            Employee employee = null;
            if(employees == null) throw new Exception("There is no Employess Present");
            for(int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Name.ToLower().Contains(employeeName.ToLower())) 
                {
                    employee = employees[i];
                    break;
                }
            }
            if (employee == null) ThrowingNullExeception("name");
            return employee.EmployeeDepartment.Name;
        }
    }
}
