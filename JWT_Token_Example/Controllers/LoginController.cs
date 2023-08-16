using Authentication_Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Authentication_Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserApplicationDbContext _dbContext;

        public LoginController(IConfiguration configuration, UserApplicationDbContext dbContext)
        {
            _config = configuration;
            _dbContext = dbContext;
        }

        private Users AuthenticateUser(Users users)
        {

            var validateUser = _dbContext.Users.FirstOrDefault(u => u.UserName == users.UserName && u.Password == users.Password && u.EmailAddress == users.EmailAddress && u.IsDeleted ==false);
            Users _user = null;
            if (validateUser != null)
            {
                _user = new Users() { UserName = users.UserName, Password = users.Password, EmailAddress = users.EmailAddress, IsDeleted = true };
            }

            return _user;
        }

        private string GenerateToken(Users users)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Users users)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(users);
            if (user != null)
            {
                var token = GenerateToken(users);
                response = Ok(new { token = token });
            }
            return response;
        }
    }
}
