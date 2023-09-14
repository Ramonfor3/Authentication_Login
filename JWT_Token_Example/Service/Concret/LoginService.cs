using Authentication_Login.Dtos.LoginUsers;
using Authentication_Login.Models;
using Authentication_Login.Repository.Abstract;
using Authentication_Login.Response;
using Authentication_Login.Service.Abstract;
using AutoMapper;

namespace Authentication_Login.Service.Concret
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;
        private readonly IMapper _mapper;

        public LoginService(ILoginRepository loginRepository, IMapper mapper)
        {
            _repository = loginRepository;
            _mapper = mapper;
        }

        public Task<ApiResponse<LoginUserDto>> AuthenticateUser(LoginUserDto users)
        {
            var apiResponse = new ApiResponse<LoginUserDto>();
            var loginMapped = _repository.AuthenticateUser(_mapper.Map<Users>(users));
            if (loginMapped == null) throw new Exception("Sorry Invalid Credentials, Try Again");
            apiResponse.result = new ResultBody<LoginUserDto>
            {
            };
            return Task.FromResult(apiResponse);
        }
    }
}
