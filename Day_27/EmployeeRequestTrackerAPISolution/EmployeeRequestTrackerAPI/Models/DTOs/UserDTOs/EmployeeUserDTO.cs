using System.ComponentModel.DataAnnotations;


namespace EmployeeRequestTrackerAPI.Models.DTOs.UserDTOs
{
    public class EmployeeUserDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string Image { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
