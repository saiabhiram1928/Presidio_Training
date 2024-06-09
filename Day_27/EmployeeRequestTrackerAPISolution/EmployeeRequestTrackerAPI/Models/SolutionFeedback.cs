namespace EmployeeRequestTrackerAPI.Models
{
    public class SolutionFeedback
    {
        public int FeedbackId { get; set; }
        public float Rating { get; set; }
        public string? Remarks { get; set; }
        public int SolutionId { get; set; }
        public RequestSolution Solution { get; set; }
        public int? FeedbackBy { get; set; }
        public Employee? FeedbackByEmployee { get; set; }
        public DateTime? FeedbackDate { get; set; }
    }
}
