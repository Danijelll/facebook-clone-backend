using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;
using FacebookClone.BLL.Services.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FacebookClone.BLL.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IUserService _userService;
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly IConfiguration _configuration;

        public JwtTokenService(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _tokenHandler = new JwtSecurityTokenHandler();
            _configuration = config;
        }

        public string GenerateJwt(LoginDTO userLogin)
        {
            UserDTO found = _userService.GetByUsername(userLogin.Username);

            _userService.PasswordMatches(found.Password, userLogin.Password);

            byte[] key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", found.Id.ToString()),
                    new Claim(ClaimTypes.Role, found.Role.ToString()),
                    new Claim("is_banned", found.IsBanned.ToString()),
                    new Claim("is_email_confirmed", found.IsEmailConfirmed.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                Audience = _configuration["LocalHost"],
                Issuer = _configuration["LocalHost"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }
    }
}