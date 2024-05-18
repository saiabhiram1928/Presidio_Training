using EmployeeReqTrackerDALLibrary;
using EmployeeReqTrackerModelLibrary;
using EmployeeReqTrackerModelLibrary.Context;
using EmployeeReqTrackerModelLibrary.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerBLLibrary
{
    public class SolutionBL
    {
        SolutionRepository _repository;
        public SolutionBL()
        {
            _repository = new SolutionRepository(new EmployeeReqTrackerContext());
        }
        public async Task<bool> AddCommentToSolution(string msg , int Id)
        {
            var sol = await _repository.GetById(Id);
            if (sol == null) throw new NullReferenceException("The Solution With Given Doesnt Exits");
            sol.RequestRaiserComment = msg;
           var res =  _repository.Update(sol);
            if(res == false) { throw new Exception("Something went Wrong , Please Try again"); }
            return true;

        }
        public async Task<Solution> GetSolutionById(int id)
        {
            var res = await _repository.GetById(id);
            if (res == null) throw new NullReferenceException("No Solution With Given Id");
            return res;
        }
        public async Task<bool> AddSolution(string solText , int reqId, int empId)
        {
            Solution sol = new Solution() { SolutionText = solText, RequestId = reqId, SolvedDate = DateTime.Now, IsSolutionAccepted = false, SolvedBy = empId };
            var res = await _repository.Add(sol);
            if (res == null) return false;
            return true;
        }
        public  async Task AceptSolution(Solution sol)
        {
            
            sol.IsSolutionAccepted = true;
            _repository.Update(sol);
        }
       public async Task<IList<Solution>> GetAllSolutions()
        {
            return await _repository.GetAll();
        }
    }
}
