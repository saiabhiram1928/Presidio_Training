namespace EmployeeRequestTrackerAPI.Models.DTOs.UserDTOs
{
    public class LoginReturnDTO
    {
        public int EmployeeID { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
