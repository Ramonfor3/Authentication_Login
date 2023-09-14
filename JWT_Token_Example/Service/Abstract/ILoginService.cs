using Authentication_Login.Dtos.LoginUsers;
using Authentication_Login.Response;

namespace Authentication_Login.Service.Abstract
{
    public interface ILoginService
    {
        public Task<ApiResponse<LoginUserDto>> AuthenticateUser(LoginUserDto users);
        
    }
}
