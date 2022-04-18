using FacebookClone.BLL.DTO.Auth;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IJwtTokenService
    {
        public string GenerateJwt(LoginDTO userLogin);
    }
}