using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeReqTrackerModelLibrary
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public override string ToString()
        {
            return Id + " " + Name + " " + Role;
        }
        public virtual bool PasswordCheck(string password)
        {
            return this.Password == password;
        }
        
        public ICollection<Request> RequestsRaised { get; set; } = new List<Request>();
        public ICollection<Request> RequestsClosed { get; set; } = new List<Request>();
        public ICollection<Solution> SolutionsProvided { get; set; } = new List<Solution>();
        public ICollection<Feedback> FeedbacksProvided { get; set; } = new List<Feedback>();

    }
}
