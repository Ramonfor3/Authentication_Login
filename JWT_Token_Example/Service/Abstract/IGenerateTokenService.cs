using Authentication_Login.Dtos.LoginUsers;
using Authentication_Login.Models;

namespace Authentication_Login.Service.Abstract
{
    public interface IGenerateTokenService
    {
        public string GenerateToken(LoginUserDto users);
    }
}
