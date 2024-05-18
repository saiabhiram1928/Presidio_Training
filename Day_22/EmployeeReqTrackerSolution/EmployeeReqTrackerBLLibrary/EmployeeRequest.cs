using EmployeeReqTrackerDALLibrary;
using EmployeeReqTrackerModelLibrary;
using EmployeeReqTrackerModelLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerBLLibrary
{
    public class EmployeeRequest
    {
        private readonly RequestRepository _reqRepository;
        private readonly EmployeeRepository _empRepository;
        public EmployeeRequest() 
        {
            
            _reqRepository = new RequestRepository(new EmployeeReqTrackerContext());
            _empRepository = new EmployeeRepository(new EmployeeReqTrackerContext());
        }
        public async Task<IList<Request>> AllRequestsRaised(int id)
        {
            var res= await _empRepository.GetAllRequestsOfEmployee(id);
            if (res.RequestsRaised == null || res.RequestsRaised.Count == 0) return null;
            return res.RequestsRaised.ToList();
            
        }
        
    }
}
