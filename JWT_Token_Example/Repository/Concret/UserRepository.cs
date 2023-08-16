using Authentication_Login.Models;
using Authentication_Login.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Login.Repository.Concret
{
    public class UserRepository : IUserRepository
    {
        private readonly UserApplicationDbContext _dbContext;

        public UserRepository(UserApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users> AddUser(Users users)
        {
            _dbContext.Users.Add(users);
            await _dbContext.SaveChangesAsync();
            return users;
        }

        public virtual async Task<IEnumerable<Users>> GetAll() => await _dbContext.Users.AsNoTracking().ToListAsync();
        public virtual async Task<IEnumerable<Users>> GetById(int Id) => await _dbContext.Users.Where(x => x.Id == Id).ToListAsync();
        public virtual async Task<IEnumerable<Users>> GetByUserName(string name) => await _dbContext.Users.Where(x => x.UserName == name).ToListAsync();


        public bool validateUserName(string user)
        {
            var exist = _dbContext.Users.Any(x => x.UserName == user);
            if (exist)
            {
                return false;
            }
            return true;
        }
    }
}
