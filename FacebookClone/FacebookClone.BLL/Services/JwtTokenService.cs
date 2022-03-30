using FacebookClone.BLL.Exceptions;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FacebookClone.BLL.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtTokenService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public string GenerateJwt(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes("temp");

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256)
            };

            SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);
            return _tokenHandler.WriteToken(token);
        }

        public JwtSecurityToken Verify(string token)
        {
            JwtSecurityToken validatedToken = VerifyToken(token);
            VerifyUser(validatedToken);

            return validatedToken;
        }

        private void VerifyUser(JwtSecurityToken validatedToken)
        {
            int userId = int.Parse(validatedToken.Claims.First(e => e.Type == "id").Value);

            User user = _userRepository.GetById(userId);

            if (user == null)
                throw BusinessExceptions.InvalidJwtTokenException;
        }

        private JwtSecurityToken VerifyToken(string token)
        {
            try
            {
                byte[] key = Encoding.ASCII.GetBytes("temp");

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