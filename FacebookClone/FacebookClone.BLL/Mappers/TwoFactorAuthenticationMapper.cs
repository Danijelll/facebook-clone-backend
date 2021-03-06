using FacebookClone.BLL.DTO.Auth;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class TwoFactorAuthenticationMapper
    {
        public static TwoFactorAuthenticationDTO ToDTO(this TwoFactorAuthentication twoFactorAuthentication)
        {
            return new TwoFactorAuthenticationDTO
            {
                Id = twoFactorAuthentication.Id,
                Username = twoFactorAuthentication.Username,
                TwoFactorCode = twoFactorAuthentication.TwoFactorCode,
                CreatedOn = twoFactorAuthentication.CreatedOn,
                UpdatedOn = twoFactorAuthentication.UpdatedOn,
            };
        }

        public static TwoFactorAuthentication ToEntity(this TwoFactorAuthenticationDTO twoFactorAuthentication)
        {
            return new TwoFactorAuthentication
            {
                Id = twoFactorAuthentication.Id,
                Username = twoFactorAuthentication.Username,
                TwoFactorCode = twoFactorAuthentication.TwoFactorCode,
                CreatedOn = twoFactorAuthentication.CreatedOn,
                UpdatedOn = twoFactorAuthentication.UpdatedOn,
            };
        }
    }
}