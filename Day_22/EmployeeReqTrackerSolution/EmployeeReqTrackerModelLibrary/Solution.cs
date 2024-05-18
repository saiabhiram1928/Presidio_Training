using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerModelLibrary
{
    public class Solution
    {
        public int Id { get; set; }   
        public string SolutionText { get; set; }
        public int RequestId { get; set; }
        public Request RequestRaisedBy { get; set; }
        public int SolvedBy { get; set; }

        public Employee RequestSolvedBy { get; set; }
        
        public bool IsSolutionAccepted { get; set; }
        public DateTime SolvedDate { get; set; }
        public string? RequestRaiserComment { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public override string ToString()
        {
            return $"Solution Id : {Id} \n Solution Text : {SolutionText} \n Resolved By Employee Id : {SolvedBy} \n SolvedDate : {SolvedDate} \n " +
                $"Solution Status : {IsSolutionAccepted} \n Request Raiser Commented : {RequestRaiserComment}";

        }
    }
}
