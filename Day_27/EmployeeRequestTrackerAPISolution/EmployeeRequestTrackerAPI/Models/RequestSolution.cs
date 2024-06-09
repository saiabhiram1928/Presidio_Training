using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerAPI.Models
{
    public class RequestSolution
    {
        [Key]
        public int SolutionId { get; set; }

        public int RequestId { get; set; }

        public Request RequestRaised { get; set; }

        public string SolutionDescription { get; set; }

        public int? SolvedBy { get; set; }

        public Employee? SolvedByEmployee { get; set; }

        public DateTime? SolvedDate { get; set; }
        public bool? IsSolved { get; set; } = false;
        public string? RequestRaiserComment { get; set; }
        public ICollection<SolutionFeedback>? Feedbacks { get; set; }
    }
}
