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
            List<string> mess = await ValidRegisterModel(userDTO);
            //ToDo vochte stuge mess != null ayl mess.Count > 0 , qani vor mess@ misht null che
            if (mess != null)
            {
                //ToDo CustomValidationException@ bdi stana nayev stringneri list
                throw new CustomValidationException("");
            }
            return await _userSQLRepository.Register(userDTO);
        }

        //ToDo functioni anun@ dir validateRegisterModel
        private async Task<List<string>> ValidRegisterModel(UserRegisterDTO userDTO)
        {
            List<string> messages = new List<string>();

            if (userDTO.Name == null)
            {
                messages.Add("Name is invalid");
            }
            //ToDo stex ete hankarc name@ null exav length@ kancheluc exception kqce, mtace inchx poxes
            if (userDTO.Name.Length < 2)
            {
                messages.Add("Name characters are less than two");
            }
            if (userDTO.Surname == null)
            {
                messages.Add("surname is invalid");
            }
            //ToDo stex ete hankarc surname@ null exav length@ kancheluc exception kqce, mtace inchx poxes
            if (userDTO.Surname.Length < 3)
            {
                messages.Add("surname charactersare less then 3");
            }

            Regex emailRegex = new Regex(@"^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$");
            Match emailMatch = emailRegex.Match(userDTO.Email);
            if (!emailMatch.Success)
            {
                messages.Add("Email is invalid.");
            }

            //Todo avelcra stugum or email@ bazayi mej arden goyutyun chuni

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
