using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class UserMapper
    {
        public static UserDTO toDTO(this User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                IsEmailConfirmed = user.IsEmailConfirmed,
                ProfileImage = user.ProfileImage,
                CoverImage = user.CoverImage,
                CreatedOn = user.CreatedOn,
                UpdatedOn = user.UpdatedOn,
            };
        }

        public static User ToEntity(this UserDTO user)
        {
            return new User()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                IsEmailConfirmed = user.IsEmailConfirmed,
                ProfileImage = user.ProfileImage,
                CoverImage = user.CoverImage,
                CreatedOn = user.CreatedOn,
                UpdatedOn = user.UpdatedOn,
            };
        }
    }
}