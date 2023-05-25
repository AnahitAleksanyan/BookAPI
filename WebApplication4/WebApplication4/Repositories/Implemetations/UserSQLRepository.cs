

using Microsoft.EntityFrameworkCore;
using WebApplication4.DTOs;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;

namespace WebApplication4.Repositories.Implemetations
{
    public class UserSQLRepository : IUserRepository
    {

        private readonly SQLDBContext _dbContext;
        public UserSQLRepository(SQLDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Exist(string email)
        {
            return await  _dbContext.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> Register(UserRegisterDTO userDTO)
        {
            User user = userDTO.ToUser();
             
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Login(UserLoginDTO userLoginDTO)
        {
            //ToDo ays qayl@ animast e
            User user = userLoginDTO.ToUser();
            //ToDo petq e lini ayspes ---- return await _dbContext.Users.Where(u => u.Email == userLoginDTO.Email && u.Password == userLoginDTO.Password).FirstOrDefaultAsync();
            return await _dbContext.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefaultAsync();
        }
    }
} 
