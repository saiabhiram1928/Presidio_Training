using System.ComponentModel.DataAnnotations.Schema;

namespace Firstwebapi.Models
{
    public class User
    {
        public int EmployeeId { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordHashKey { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public string Status { get; set; }

    }
}
