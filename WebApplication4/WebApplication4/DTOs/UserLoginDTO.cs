using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class UserLoginDTO
    {
        public string Email { get; set; }   
        public string Password { get; set; }

        public User ToUser()
        {
            User user = new User();
            user.Email = Email;
            user.Password = Password;
            return user;
        }
    }
}
