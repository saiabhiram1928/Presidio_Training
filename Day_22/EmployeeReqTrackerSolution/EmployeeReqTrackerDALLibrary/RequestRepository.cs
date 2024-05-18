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
    public class RequestRepository : IRepository<int, Request>
    {
        EmployeeReqTrackerContext _context;
        public RequestRepository(EmployeeReqTrackerContext context) 
        {
            _context = context;
        }
        public async Task<Request> Add(Request item)
        {
            if (item == null) return null;
            try
            {
              
                await _context.Requests.AddAsync(item);
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

                _context.Requests.Remove(request);
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

        public async Task<IList<Request>> GetAll()
        {
            try
            {
                return await _context.Requests.ToListAsync();
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

        public async Task<Request> GetById(int key)
        {
            try
            {
                var req = await _context.Requests.FindAsync(key);
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

        public bool Update(Request item)
        {
            try
            {
                _context.Requests.Update(item);
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
        public async Task<Request> GetRequestWithSolutionsAsync(int requestId)
        {
            _context.ChangeTracker.Clear();
            var req = await _context.Requests
                                 .Include(r => r.RequestSolutions)
                                 .FirstOrDefaultAsync(r => r.Id == requestId);
            return req;
        }

    }
}
