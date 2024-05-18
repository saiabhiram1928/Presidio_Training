using EmployeeReqTrackerDALLibrary;
using EmployeeReqTrackerModelLibrary;
using EmployeeReqTrackerModelLibrary.Context;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerBLLibrary
{
   public class FeedbackBl
    {
        FeedbackRepository _repository;
        public FeedbackBl() 
        {
            _repository = new FeedbackRepository(new EmployeeReqTrackerContext());
        }
       public async Task<Feedback> AddFeedBack(Feedback feedback)
        {
            var res = await _repository.Add(feedback);
            if(res == null) { throw new NullReferenceException("Something Went Wrong While adding Feedback"); }
            return res;

        } 
    }
}
