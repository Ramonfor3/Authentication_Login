using Authentication_Login.Dtos.LoginUsers;
using Authentication_Login.Response;
using Authentication_Login.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IGenerateTokenService _generateToken;
        private readonly ILoginService _login;

        public LoginController(IGenerateTokenService generateToken, ILoginService login)
        {
            _generateToken = generateToken;
            _login = login;
        }

        [Authorize]
        [HttpPost("Authentication")]
        public Task<ApiResponse<LoginUserDto>> AuthenticateUser(LoginUserDto users) => _login.AuthenticateUser(users);

        [AllowAnonymous]
        [HttpPost("GenerateToken")]
        public IActionResult Login(LoginUserDto users)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(users);
            if (user != null)
            {
                var token = _generateToken.GenerateToken(users);
                response = Ok(new { token = $"Bearer {token}" });
            }
            return response;
        }
    }
}
