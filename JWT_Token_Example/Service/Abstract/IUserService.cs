using Authentication_Login.Dtos.Users;
using Authentication_Login.Response;

namespace Authentication_Login.Service.Abstract
{
    public interface IUserService
    {
        Task<ApiResponse<GetUserDto>> GetAll();
        public Task<ApiResponse<GetUserDto>> GetById(int id);
        public Task<ApiResponse<GetUserDto>> GetByUserName(string name);
        public Task<UserDto> AddUser(CreateUserDto users);
    }
}
