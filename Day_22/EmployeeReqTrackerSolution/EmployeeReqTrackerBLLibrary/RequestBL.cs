using EmployeeReqTrackerDALLibrary;
using EmployeeReqTrackerModelLibrary.Context;
using EmployeeReqTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EmployeeReqTrackerBLLibrary.Exceptions;

namespace EmployeeReqTrackerBLLibrary
{
    public class RequestBL
    {
        private readonly RequestRepository _repository;
        public RequestBL()
        {
            _repository = new RequestRepository(new EmployeeReqTrackerContext());
             
        }
        public async Task<Request> AddRequest(Employee emp,string msg)
        {
            
            Request req = new Request() { 
                RequestDate = DateTime.Now,
                RequestStatus = "Open",
                RequestMessage = msg,
                RequestRaisedBy = emp.Id 
            }; 
            var res = await _repository.Add(req);
            if(res == null) { throw new DuplicateObjectException(); }
            return req;
        }
        public async Task<Request> GetSolutionsOfAReq(int id)
        {
            var req = await _repository.GetRequestWithSolutionsAsync(id);
            return req;
        }
        public async Task<bool> CloseRequest(int reqid , int empId)
        {
            var req = await _repository.GetById(reqid);
            if (req == null) throw new NullReferenceException("No Request Present With Given Id");
            req.RequestClosedBy = empId;
            req.RequestStatus = "Closed";
            req.ClosedDate =  DateTime.Now;
            var res  = _repository.Update(req);
            return true;
        }
        public async Task<bool> CheckIsReqClosed(int id)
        {
            var req = await _repository.GetById(id);
            if (req == null) throw new NullReferenceException("Give a Valid Request Id");
            if(req.RequestStatus.ToLower() == "Closed" ) return true;
            return false;
        }
        public async Task<IList<Request>> GetAllRequests()
        {
            var res = await _repository.GetAll();
            return res;
        }
        
        public async Task<Request> GetRequest(int id)
        {
            var req = await _repository.GetById(id);
            if (req == null) throw new NullReferenceException("The Request With given Id Doesnt exist");
            return req;
        }
       
    }
}
