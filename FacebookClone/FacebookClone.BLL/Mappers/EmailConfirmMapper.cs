using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class EmailConfirmMapper
    {
        public static EmailConfirmDTO ToDTO(this EmailConfirm emailConfirm)
        {
            return new EmailConfirmDTO()
            {
                Id = emailConfirm.Id,
                UserId = emailConfirm.UserId,
                EmailHash = emailConfirm.EmailHash,
            };
        }

        public static EmailConfirm ToEntity(this EmailConfirmDTO emailConfirm)
        {
            return new EmailConfirm()
            {
                Id = emailConfirm.Id,
                UserId = emailConfirm.UserId,
                EmailHash = emailConfirm.EmailHash,
            };
        }
    }
}