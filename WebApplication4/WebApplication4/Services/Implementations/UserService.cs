using System.Text.RegularExpressions;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userSQLRepository;
        public UserService(IUserRepository userSQLRepository)
        {
            _userSQLRepository = userSQLRepository;
        }

        public async Task<User> Register(UserRegisterDTO userDTO)
        {
            List<string> mess = await ValidateRegisterModel(userDTO);
            
            if (mess.Count > 0)
            {
                foreach (string message in mess)
                {
                    throw new CustomValidationException(message);
                }
            }           
             return   await _userSQLRepository.Register(userDTO);                    
        }

        public async Task<User> Login(UserLoginDTO userLoginDTO)
        {
           User userLogin =  await _userSQLRepository.Login(userLoginDTO);
            if (userLogin == null)
            {
                throw new CustomValidationException("There is no registered user");
            }
            return userLogin;
        }
        
        private async Task<List<string>> ValidateRegisterModel(UserRegisterDTO userDTO)
        {
            List<string> messages = new List<string>();

            if (userDTO.Name == null)
            {
                messages.Add("Name is invalid");
            }
            
            if (userDTO.Name != null && userDTO.Name.Length < 2)
            {
                messages.Add("Name characters are less than two");
            }
            if (userDTO.Surname == null)
            {
                messages.Add("surname is invalid");
            }
            
            if (userDTO.Surname != null && userDTO.Surname.Length < 3)
            {
                messages.Add("surname characters are less then 3");
            }

            Regex emailRegex = new Regex(@"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$");
            Match emailMatch = emailRegex.Match(userDTO.Email);
            if (!emailMatch.Success)
            {
                messages.Add("Email is invalid.");
            }

            bool emailExists = await _userSQLRepository.Exist(userDTO.Email);
            if (emailExists)
            {
                messages.Add("Email is already exists in database");
            }
           
            Regex passwordRegex = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Match passwordMatch = passwordRegex.Match(userDTO.Password);
            if (!passwordMatch.Success)
            {
                messages.Add("Password is invalid");
            }
            if (userDTO.ConfirmPassword != userDTO.Password)
            {
                messages.Add("Confirmpassword is invalid");
            }
            return messages;
        }
    }
}
