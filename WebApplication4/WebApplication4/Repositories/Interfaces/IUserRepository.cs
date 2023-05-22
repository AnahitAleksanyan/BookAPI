using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Register(UserRegisterDTO userDTO);

        Task<bool> Exist(string email);

        Task<User> Login(UserLoginDTO userLoginDTO);
    }
}
