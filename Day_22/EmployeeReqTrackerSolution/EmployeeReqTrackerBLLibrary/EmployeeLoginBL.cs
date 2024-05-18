using EmployeeReqTrackerBLLibrary.Exceptions;
using EmployeeReqTrackerDALLibrary;
using EmployeeReqTrackerModelLibrary;
using EmployeeReqTrackerModelLibrary.Context;
using System.Runtime.CompilerServices;

namespace EmployeeReqTrackerBLLibrary
{
    public class EmployeeLoginBL : IEmployeeLoginBL
    {
        private readonly IRepository<int, Employee> _repository;
        public EmployeeLoginBL()
        {
            IRepository<int, Employee> repo = new EmployeeRepository(new EmployeeReqTrackerContext());
            _repository = repo;
        }

        public async Task<Employee> GetDetailsEmployee(int key)
        {
            
                var res = await _repository.GetById(key);
                return res;
        }

        public async Task<bool> Login(Employee employee)
        {
            
            Employee emp;
            try 
            {
            
                emp = await _repository.GetById(employee.Id);
               
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
          
            if (emp == null)
            {
                throw new NullReferenceException("Employee With Given Obj not found"); 
            }
            
            return emp.Password == employee.Password;
        }

        public async Task<Employee> Register(Employee employee)
        {
            employee.Role = "User";
            await Console.Out.WriteLineAsync($"{employee}");

            var result = await _repository.Add(employee);
            return result;
        }
        public async Task<bool> CheckEmpExists(int id)
        {
            var emp = await _repository.GetById(id);
            if (emp == null) return false;
            return true;
        }
    }
}
