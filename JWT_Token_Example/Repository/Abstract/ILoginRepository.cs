using Authentication_Login.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Login.Repository.Abstract
{
    public interface ILoginRepository
    {
        public Users AuthenticateUser(Users users);
    }
}
