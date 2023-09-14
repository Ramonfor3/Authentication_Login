using Authentication_Login.Models;
using Authentication_Login.Repository.Abstract;

namespace Authentication_Login.Repository.Concret
{
    public class LoginRepository : ILoginRepository
    {
        private readonly UserApplicationDbContext _dbContext;

        public LoginRepository(UserApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Users AuthenticateUser(Users users)
        {
            var validateUser = _dbContext.Users.FirstOrDefault(u => u.UserName == users.UserName && u.Password == users.Password && u.IsDeleted == false);
            Users _user = null;
            if (validateUser != null)
            {
                _user = new Users() { UserName = users.UserName, Password = users.Password, IsDeleted = true };
            }

            return _user;
        }

    }
}
