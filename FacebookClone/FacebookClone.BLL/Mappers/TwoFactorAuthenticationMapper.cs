using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.BLL.Mappers
{
    public static class TwoFactorAuthenticationMapper
    {
        public static TwoFactorAuthenticationDTO ToDTO(this TwoFactorAuthentication twoFactorAuthentication)
        {
            return new TwoFactorAuthenticationDTO
            {
                Id = twoFactorAuthentication.Id,
                UserId = twoFactorAuthentication.UserId,
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
                UserId = twoFactorAuthentication.UserId,
                TwoFactorCode = twoFactorAuthentication.TwoFactorCode,
                CreatedOn = twoFactorAuthentication.CreatedOn,
                UpdatedOn = twoFactorAuthentication.UpdatedOn,
            };
        }
    }
}
