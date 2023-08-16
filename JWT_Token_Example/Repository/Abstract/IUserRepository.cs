using Authentication_Login.Dtos;
using Authentication_Login.Models;

namespace Authentication_Login.Repository.Abstract
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Users>> GetAll();
        public Task<IEnumerable<Users>> GetById(int id);
        public Task<IEnumerable<Users>> GetByUserName(string name);
        Task<Users> AddUser(Users users);

        public bool validateUserName(string user);
    }
}
