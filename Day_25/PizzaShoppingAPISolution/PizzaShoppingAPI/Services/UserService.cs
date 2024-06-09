using PizzaShoppingAPI.Exceptions;
using PizzaShoppingAPI.Interfaces;
using PizzaShoppingAPI.Models;
using PizzaShoppingAPI.Models.DTOs;
using System.Security.Cryptography;
using System.Text;

namespace PizzaShoppingAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<int, User> _userRepo;
        private readonly IRepository<int, Customer> _CustomerRepo;
        private readonly ITokenService _tokenService;

        public UserService(IRepository<int, User> userRepo, IRepository<int, Customer> CustomerRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _CustomerRepo = CustomerRepo;
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
                var Customer = await _CustomerRepo.GetByKey(loginDTO.UserId);
                // if(userDB.Status =="Active")
                //{
                LoginReturnDTO loginReturnDTO = MapCustomerToLoginReturn(Customer);
                return loginReturnDTO;
                // }

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

        public async Task<Customer> Register(CustomerUserDTO CustomerDTO)
        {
            Customer Customer = null;
            User user = null;
            try
            {
                Customer = CustomerDTO;
                user = MapCustomerUserDTOToUser(CustomerDTO);
                Customer = await _CustomerRepo.Add(Customer);
                user.CustomerId = Customer.Id;
                user = await _userRepo.Add(user);
                ((CustomerUserDTO)Customer).Password = string.Empty;

                return Customer;
            }
            catch (Exception) { }
            if (Customer != null)
                await RevertCustomerInsert(Customer);
            if (user != null && Customer == null)
                await RevertUserInsert(user);
            throw new UnableToRegisterException("Not able to register at this moment");
        }

        private LoginReturnDTO MapCustomerToLoginReturn(Customer Customer)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.CustomerID = Customer.Id;
            returnDTO.Role = Customer.Role ?? "User";
            returnDTO.Token = _tokenService.GenerateToken(Customer);
            return returnDTO;
        }

        private async Task RevertUserInsert(User user)
        {
            await _userRepo.DeleteByKey(user.CustomerId);
        }

        private async Task RevertCustomerInsert(Customer Customer)
        {

            await _CustomerRepo.DeleteByKey(Customer.Id);
        }

        private User MapCustomerUserDTOToUser(CustomerUserDTO CustomerDTO)
        {
            User user = new User();
            user.CustomerId = CustomerDTO.Id;
            user.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            user.PasswordHashKey = hMACSHA.Key;
            user.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(CustomerDTO.Password));
            return user;
        }
    }
}
