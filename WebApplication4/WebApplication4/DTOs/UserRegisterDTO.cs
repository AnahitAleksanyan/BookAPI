using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class UserRegisterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }


        public User ToUser()
        {
            User user = new User();
            user.Name = Name;   
            user.Surname = Surname;
            user.Email = Email;
            user.Password = Password;
            user.ConfirmPassword = ConfirmPassword;
            return user;
        }
    }
}
