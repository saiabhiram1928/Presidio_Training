using EmployeeRequestTrackerAPI.Contexts;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _repository;
        private readonly IRepository<int, Employee> _employeeRepository;

        public RequestService(IRepository<int, Request> repository, IRepository<int, Employee> employeeRepository)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
        }

        public async Task<Request> RaiseRequest(Request request)
        {
            var addedRequest = await _repository.Add(request);
            return addedRequest;
        }

        public async Task<IEnumerable<Request>> ViewOpenRequests(int id)
        {
            IEnumerable<Request> requests;
            var employee = await _employeeRepository.GetByKey(id);

            // If the user is an admin, view all requests
            if (employee.Role == "Admin")
            {
                requests = await _repository.Get();
            }
            else // For normal users, view only their requests
            {
                requests = await _repository.Get();
                requests = requests.Where(r => r.RequestRaisedBy == employee.Id).ToList();
            }
            requests = requests.Where(r => r.RequestStatus == "Open").ToList();
            requests = requests.OrderBy(r => r.RequestDate);
            return requests;
        }

        public async Task<ICollection<RequestSolution>> ViewSolutions(int requestId)
        {

            var request = await _repository.GetByKey(requestId);

            if (request != null)
            {
                return request.RequestSolutions;
            }
            else
            {
                return new List<RequestSolution>();
            }
        }

    }
}
