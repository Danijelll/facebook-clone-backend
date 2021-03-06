using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;
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
        private readonly ITwoFactorAuthenticatorRepository _twoFactorAuthenticatorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public JwtTokenService(IUserService userService, ITwoFactorAuthenticatorRepository twoFactorAuthenticatorRepository, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _userService = userService;
            _tokenHandler = new JwtSecurityTokenHandler();
            _twoFactorAuthenticatorRepository = twoFactorAuthenticatorRepository;
            _unitOfWork = unitOfWork;
            _configuration = config;
        }

        public string GenerateJwt(string username, string twoFactorCode)
        {
            UserDTO found = _userService.GetByUsername(username);

            TwoFactorAuthentication foundTwoFactor = _twoFactorAuthenticatorRepository.GetByUserUsername(username);

            if (twoFactorCode == null ||twoFactorCode != foundTwoFactor?.TwoFactorCode)
            {
                throw BusinessExceptions.NotAuthorizedException;
            }

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

            _twoFactorAuthenticatorRepository.Delete(foundTwoFactor.Id);
            _unitOfWork.SaveChanges();

            SecurityToken token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }
    }
}