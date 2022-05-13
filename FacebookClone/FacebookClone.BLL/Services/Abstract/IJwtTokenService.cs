using FacebookClone.BLL.DTO.Auth;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IJwtTokenService
    {
        public string GenerateJwt(string email, string twoFactorCode);
    }
}