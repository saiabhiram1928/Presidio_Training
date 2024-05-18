using EmployeeReqTrackerModelLibrary;
using EmployeeReqTrackerModelLibrary.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerDALLibrary
{
    public class SolutionRepository :IRepository<int,Solution> 
    {
        EmployeeReqTrackerContext _context;
        public SolutionRepository(EmployeeReqTrackerContext context)
        {
            _context = context;
        }

        public async Task<Solution> Add(Solution item)
        {
            if (item == null) return null;
            try
            {
                
                await _context.AddAsync(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex}");

            }
            return null;
        }

        public async Task<bool> Delete(int key)
        {
            try
            {
                var request = await GetById(key);
                if (request == null) return false;

                _context.Remove(request);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
              
            }
            return false;
        }

        public async Task<IList<Solution>> GetAll()
        {
            try
            {
                return await _context.Solutions.ToListAsync();
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
               
            }
            return null;
        }

        public async Task<Solution> GetById(int key)
        {
            try
            {
                var req = await _context.Solutions.FindAsync(key);
                return req;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
            return null;
        }

        public bool Update(Solution item)
        {
            try
            {
                _context.Solutions.Update(item);
                _context.SaveChanges();
                return true;
            }
            catch (DbException dbEx)
            {
                Console.WriteLine($"Database error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return false;
        }
    }
}
