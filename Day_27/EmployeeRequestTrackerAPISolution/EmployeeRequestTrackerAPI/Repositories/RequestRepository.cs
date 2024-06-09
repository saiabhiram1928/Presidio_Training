using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        private readonly RequestTrackerContext _context;
        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<Request> Add(Request item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Request> DeleteByKey(int key)
        {
            var Request = await GetByKey(key);
            if (Request != null)
            {
                _context.Remove(Request);
                _context.SaveChangesAsync(true);
                return Request;
            }
            throw new NoSuchRequestException();
        }

        public Task<Request> GetByKey(int key)
        {
            var Request = _context.Requests.FirstOrDefaultAsync(r => r.RequestNumber == key);
            return Request;
        }

        public async Task<IEnumerable<Request>> Get()
        {
            try
            {
                var requests = await _context.Requests.ToListAsync();
                return requests;
            } catch (Exception)
            {
                throw new NoRequestsFoundException();
            }
            

        }

        public async Task<Request> Update(Request item)
        {
            var Request = await GetByKey(item.RequestNumber);
            if (Request != null)
            {
                _context.Update(item);
                _context.SaveChangesAsync(true);
                return Request;
            }
            throw new NoSuchRequestException();
        }
    }
}
