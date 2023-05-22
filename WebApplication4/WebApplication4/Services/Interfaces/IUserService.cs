using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Register(UserRegisterDTO userDTO);
        Task<User> Login(UserLoginDTO userLoginDTO);
    }
}
