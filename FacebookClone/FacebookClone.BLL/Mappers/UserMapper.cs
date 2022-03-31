using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class UserMapper
    {
        public static UserDTO ToDTO(this User user)
        {
            return new UserDTO()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                IsEmailConfirmed = user.IsEmailConfirmed,
                ProfileImage = $"http://localhost:7122/{ImageConstants.UserProfileImageFolder}/{user.Id}/{user.ProfileImage}",
                CoverImage = $"http://localhost:7122/{ImageConstants.UserCoverImageFolder}/{user.Id}/{user.ProfileImage}",
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
                ProfileImage = user.ProfileImage.Split("/").Last(),
                CoverImage = user.CoverImage.Split("/").Last(),
                CreatedOn = user.CreatedOn,
                UpdatedOn = user.UpdatedOn,
            };
        }
        
        public static IEnumerable<UserDTO> ToDTOList(this IEnumerable<User> user)
        {
            return user.Select(x => x.ToDTO()).ToList();
        }
    }
}