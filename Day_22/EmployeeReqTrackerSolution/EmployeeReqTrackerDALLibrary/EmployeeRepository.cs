﻿using EmployeeReqTrackerModelLibrary;
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
                
               _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");
                return null;
            }
        }

        public async Task<bool> Delete(int key)
        {
            try
            {
                var employee = await GetById(key);
                if (employee == null) return false;

                _context.Employees.Remove(employee);
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
        public async Task<Employee> GetAllRequestsOfEmployee(int empId)
        {
            _context.ChangeTracker.Clear();
            var emp = await _context.Employees.Include(e => e.RequestsRaised)
                                 .FirstOrDefaultAsync(r => r.Id == empId);
            return emp;
        }
    }
}
