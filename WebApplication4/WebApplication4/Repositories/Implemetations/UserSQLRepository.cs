

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

        public async Task<User> Register(UserRegisterDTO userDTO)
        {
            User user = userDTO.ToUser();
            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
