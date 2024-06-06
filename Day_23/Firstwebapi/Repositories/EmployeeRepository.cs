using Firstwebapi.Contexts;
using Firstwebapi.Exceptions;
using Firstwebapi.Interfaces;
using Firstwebapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Firstwebapi.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly ReqTrackerContext _context;
        public EmployeeRepository(ReqTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Employee> Delete(int key)
        {
            var employee = await Get(key);
            if (employee != null)
            {
                Debug.WriteLine(_context.Entry(employee).State);
                _context.Remove(employee);
              await  _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchEmployeeException();
        }

        public Task<Employee> Get(int key)
        {
            var employee = _context.Employees.FirstOrDefaultAsync(e => e.Id == key);
            return employee;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees;

        }

        public async Task<Employee> Update(Employee item)
        {
            var employee = await Get(item.Id);
            if (employee != null)
            {
                _context.Update(item);
              await  _context.SaveChangesAsync(true);
                return employee;
            }
            throw new NoSuchEmployeeException();
        }
    }
}
