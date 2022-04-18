using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;
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
                CreatedOn = emailConfirm.CreatedOn,
                UpdatedOn = emailConfirm.UpdatedOn,
            };
        }

        public static EmailConfirm ToEntity(this EmailConfirmDTO emailConfirm)
        {
            return new EmailConfirm()
            {
                Id = emailConfirm.Id,
                UserId = emailConfirm.UserId,
                EmailHash = emailConfirm.EmailHash,
                CreatedOn = emailConfirm.CreatedOn,
                UpdatedOn = emailConfirm.UpdatedOn,
            };
        }

        public static EmailConfirmDTO ToEmailConfirmDTO(this UserDTO userDTO)
        {
            return new EmailConfirmDTO()
            {
                UserId = userDTO.Id,
                EmailHash = BCrypt.Net.BCrypt.HashString(userDTO.Email).Replace("/", "-")
            };
        }
    }
}