using FacebookClone.DAL.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IJwtTokenService
    {
        public string GenerateJwt(User user);
        public JwtSecurityToken Verify(string token);
    }
}