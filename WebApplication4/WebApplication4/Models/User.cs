namespace WebApplication4.Models
{
    //ToDo bazayi mej ConfirmPassword chpetq e pahel hetevabar confirm password@ user model@ chpetq e unena , ayl miyayn registeri DTO-n
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; } 
    }
}
