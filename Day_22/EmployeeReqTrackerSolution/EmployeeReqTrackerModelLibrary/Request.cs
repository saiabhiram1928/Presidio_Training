using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerModelLibrary
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }

        
        public int RequestRaisedBy { get; set; }
        
        public Employee RequestRaisedByEmployee { get; set; }
        
        public int? RequestClosedBy { get; set; }
        
        public Employee? RequestClosedByEmployee { get; set; }
        public ICollection<Solution> RequestSolutions { get; set; } = new List<Solution>();
        public override string ToString()
        {
            return $"Request Id : {Id} \n Request Text : {RequestMessage} \n Raised By Employee : {RequestRaisedBy} \n Status : {RequestStatus} \n Request Date : {RequestDate} \n Request Closed : {ClosedDate} \n Request Closed By {RequestClosedBy} ";
        }
    }
}
