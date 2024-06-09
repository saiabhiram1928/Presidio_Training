namespace EmployeeRequestTrackerAPI.Models.DTOs.UserDTOs
{
    public class UserLoginDTO
    {
        public int UserId { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
