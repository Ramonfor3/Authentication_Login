
using Authentication_Login.Dtos.LoginUsers;
using Authentication_Login.Service.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Authentication_Login.Service.Concret
{
    public class GenerateTokenService : IGenerateTokenService
    {
        private readonly IConfiguration _config;

        public GenerateTokenService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string GenerateToken(LoginUserDto users)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddSeconds(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
