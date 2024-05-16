using EmployeeReqTrackerModelLibrary;
using EmployeeReqTrackerModelLibrary.Context;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace EmployeeReqTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly EmployeeReqTrackerContext _context;
        public EmployeeRepository(EmployeeReqTrackerContext context)
        {
            _context = context;
        }
        public async Task<Employee> Add(Employee item)
        {
            if (item == null) return null;
            try
            {
                await Console.Out.WriteLineAsync($"item in db ${item}");
                await _context.Employees.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Delete(int key)
        {
            try
            {
                var doctor = await _context.Employees.FindAsync(key);
                if (doctor == null) return false;

                _context.Employees.Remove(doctor);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public async Task<IList<Employee>> GetAll()
        {
            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }

        }

        public async Task<Employee> GetById(int key)
        {
           
            try
            {
                var emp =  _context.Employees.Find(key);
                return emp;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public bool Update(Employee item)
        {
            try
            {
                _context.Employees.Update(item);
                _context.SaveChanges();
                return true;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
