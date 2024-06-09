using EmployeeRequestTrackerAPI.Models;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestService   // handles operations related to requests for both users and admins.
    {
        Task<Request> RaiseRequest(Request request);
        Task<IEnumerable<Request>> ViewOpenRequests(int id);
        Task<ICollection<RequestSolution>> ViewSolutions(int requestId);

    }
}
