using FacebookClone.BLL.DTO;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IJwtTokenService
    {
        public string GenerateJwt(LoginDTO userLogin);
    }
}