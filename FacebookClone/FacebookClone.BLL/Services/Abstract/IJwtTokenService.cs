using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IJwtTokenService
    {
        public string GenerateJwt(LoginDTO userLogin);
        public ClaimsDTO VerifyUser(JwtSecurityToken validatedToken);
        public JwtSecurityToken VerifyToken(string token);
    }
}