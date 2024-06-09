using EmployeeRequestTrackerAPI.Exceptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs.UserDTOs;
using System.Security.Cryptography;
using System.Text;


namespace EmployeeRequestTrackerAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Employee> _employeeRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Employee> employeeRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _employeeRepo = employeeRepo;
            _tokenService = tokenService;
        }
        public async Task<LoginReturnDTO> Login(UserLoginDTO loginDTO)
        {
            var userDB = await _userRepo.GetByKey(loginDTO.UserId);
            if (userDB == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userDB.PasswordHashKey);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isPasswordSame = ComparePassword(encrypterPass, userDB.Password);
            if (isPasswordSame)
            {
                var employee = await _employeeRepo.GetByKey(loginDTO.UserId);
                //if(userDB.Status =="Active")
                //{
                LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturn(employee);
                return loginReturnDTO;
                //}

                throw new UserNotActiveException("Your account is not activated");
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Employee> Register(EmployeeUserDTO employeeDTO)
        {
            Employee employee = null;
            User user = null;
            try
            {
                employee = MapToEmployee(employeeDTO);
                user = MapEmployeeUserDTOToUser(employeeDTO);
                employee = await _employeeRepo.Add(employee);

                user.EmployeeId = employee.Id;

                user = await _userRepo.Add(user);

                return employee;
            }
            catch (Exception) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);

            if (user != null && employee == null)
                await RevertUserInsert(user);

            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private LoginReturnDTO MapEmployeeToLoginReturn(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;
            returnDTO.Role = employee.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(employee);
            return returnDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.DeleteByKey(user.EmployeeId);
        }

        private async Task RevertEmployeeInsert(Employee employee)
        {

            await _employeeRepo.DeleteByKey(employee.Id);
        }

        private User MapEmployeeUserDTOToUser(EmployeeUserDTO employeeDTO)
        {
            User user = new User();
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return user;
        }




        //  user activation logic
        public async Task<ReturnUserActivationDTO> UserActivation(UserActivationDTO userActivationDTO)
        {
            try
            {
                ReturnUserActivationDTO returnUserActivationDTO = null;

                var user = await _userRepo.GetByKey(userActivationDTO.UserId);

                if (user != null)
                {
                    if (userActivationDTO.IsActive)
                    {
                        user.Status = "Active";

                        //saving chnages in db
                        var UpdatedUser = await _userRepo.Update(user);

                        if (UpdatedUser != null)
                        {
                            returnUserActivationDTO = new ReturnUserActivationDTO
                            {
                                UserId = user.EmployeeId,
                                Status = user.Status
                            };
                        }
                        else
                        {
                            throw new Exception("Failed to update user status.");
                        }
                    }
                    else
                    {
                        throw new Exception("User activation flag is false.");
                    }
                }
                else
                {
                    throw new NoSuchUserFoundException();
                }

                return returnUserActivationDTO;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to activate user at this moment.", ex);
            }
        }

        public static Employee MapToEmployee(EmployeeUserDTO customerDTO)
        {
            return new Employee
            {
                Name = customerDTO.Name,
                DateOfBirth = customerDTO.DateOfBirth,
                Phone = customerDTO.Phone,
                Image = customerDTO.Image,
                Role = customerDTO.Role
            };
        }
    }
}
