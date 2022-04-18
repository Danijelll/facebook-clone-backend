using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO.Auth;
using FacebookClone.BLL.DTO.User;
using FacebookClone.BLL.Enums;
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
                Role = (Roles)user.Role,
                IsBanned = user.IsBanned,
                IsEmailConfirmed = user.IsEmailConfirmed,
                ProfileImage = $"http://localhost:5000/{ImageConstants.UserProfileImageFolder}/{SetImagePath(user.Id, user.ProfileImage)}",
                CoverImage = $"http://localhost:5000/{ImageConstants.UserCoverImageFolder}/{SetImagePath(user.Id, user.CoverImage)}",
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
                Role = (int)user.Role,
                IsBanned = user.IsBanned,
                IsEmailConfirmed = user.IsEmailConfirmed,
                ProfileImage = user.ProfileImage.Split("/").Last(),
                CoverImage = user.CoverImage.Split("/").Last(),
                CreatedOn = user.CreatedOn,
                UpdatedOn = user.UpdatedOn,
            };
        }

        public static UserDTO ToUserDTO(this RegisterDTO userRegister)
        {
            return new UserDTO()
            {
                Username = userRegister.Username,
                Email = userRegister.Email,
                Password = userRegister.Password,
                Role = userRegister.Role,
                IsBanned = userRegister.IsBanned,
                IsEmailConfirmed = userRegister.IsEmailConfirmed,
                ProfileImage = userRegister.ProfileImage.Split("/").Last(),
                CoverImage = userRegister.CoverImage.Split("/").Last(),
            };
        }

        public static IEnumerable<UserDTO> ToDTOList(this IEnumerable<User> user)
        {
            return user.Select(x => x.ToDTO()).ToList();
        }

        private static string SetImagePath(int id, string imageName)
        {
            if (imageName != ImageConstants.DefaultImageName)
            {
                return $"{id}/{imageName}";
            }
            return imageName;
        }
    }
}