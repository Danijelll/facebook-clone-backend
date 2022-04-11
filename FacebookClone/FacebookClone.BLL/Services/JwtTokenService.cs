using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Enums;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
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
            //UserDTO found = _userService.GetByUsername(userLogin.Username);

            //_userService.PasswordMatches(found.Password, userLogin.Password);

            UserDTO found = new UserDTO
            {
                Id = 7,
                Role = Roles.User,
                IsBanned = false,
                IsEmailConfirmed = true
            };
            
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
                Audience = "https://localhost:5001",
                Issuer = "https://localhost:5001",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }

        public ClaimsDTO VerifyUser(JwtSecurityToken validatedToken)
        {
            int userId = int.Parse(validatedToken.Claims.First(e => e.Type == "id").Value);

            UserDTO userDto = _userService.GetById(userId);

            if (userDto == null)
                throw BusinessExceptions.InvalidJwtTokenException;

            if ((Roles) Int32.Parse(validatedToken.Claims.First(e => e.Type == "role").Value) == Roles.User)
            {
                return new ClaimsDTO
                {
                    Id = int.Parse(validatedToken.Claims.First(e => e.Type == "id").Value),
                    Role = int.Parse(validatedToken.Claims.First(e => e.Type == "role").Value),
                    IsBanned = bool.Parse(validatedToken.Claims.First(e => e.Type == "is_banned").Value),
                    IsEmailConfirmed = bool.Parse(validatedToken.Claims.First(e => e.Type == "is_email_confirmed").Value)
                };
            }

            if ((Roles)Int32.Parse(validatedToken.Claims.First(e => e.Type == "role").Value) == Roles.Admin)
            {
                return new ClaimsDTO
                {
                    Id = int.Parse(validatedToken.Claims.First(e => e.Type == "id").Value),
                    Role = int.Parse(validatedToken.Claims.First(e => e.Type == "role").Value),
                };
            }

            throw BusinessExceptions.InvalidJwtTokenException;
        }

        public JwtSecurityToken VerifyToken(string token)
        {
            try
            {
                byte[] key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);

                _tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return (JwtSecurityToken)validatedToken;
            }
            catch
            {
                throw BusinessExceptions.InvalidJwtTokenException;
            }
        }
    }
}