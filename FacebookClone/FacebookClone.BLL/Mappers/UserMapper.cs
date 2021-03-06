using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO.Albums;
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
                ProfileImage = $"https://localhost:5001/{ImageConstants.UserProfileImageFolder}/{SetImagePath(user.Id, user.ProfileImage)}",
                CoverImage = $"https://localhost:5001/{ImageConstants.UserCoverImageFolder}/{SetImagePath(user.Id, user.CoverImage)}",
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

        public static UserDataDTO ToUserDataDTO(this UserDTO userDTO)
        {
            return new UserDataDTO()
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                Email = userDTO.Email,
                Role = (Roles)userDTO.Role,
                IsEmailConfirmed = userDTO.IsEmailConfirmed,
                IsBanned = userDTO.IsBanned,
                ProfileImage = userDTO.ProfileImage,
                CoverImage = userDTO.CoverImage,
                CreatedOn = userDTO.CreatedOn,
                UpdatedOn = userDTO.UpdatedOn,
            };
        }

        public static UserDTO ToUserDTO(this UserDataDTO userDataDTO)
        {
            return new UserDTO()
            {
                Id = userDataDTO.Id,
                Username = userDataDTO.Username,
                Email = userDataDTO.Email,
                Role = (Roles)userDataDTO.Role,
                IsEmailConfirmed = userDataDTO.IsEmailConfirmed,
                ProfileImage = userDataDTO.ProfileImage,
                CoverImage = userDataDTO.CoverImage,
                CreatedOn = userDataDTO.CreatedOn,
                UpdatedOn = userDataDTO.UpdatedOn,
            };
        }

        public static UserWithAlbumsDTO ToUserWithAlbumsDTO(this User userDTO, IEnumerable<AlbumWithImagesDTO> albums)
        {
            return new UserWithAlbumsDTO()
            {
                Id = userDTO.Id,
                Username = userDTO.Username,
                Email = userDTO.Email,
                Role = (Roles)userDTO.Role,
                IsEmailConfirmed = userDTO.IsEmailConfirmed,
                ProfileImage = userDTO.ProfileImage,
                CoverImage = userDTO.CoverImage,
                CreatedOn = userDTO.CreatedOn,
                UpdatedOn = userDTO.UpdatedOn,
                Albums = albums
            };
        }

        public static IEnumerable<UserDTO> ToDTOList(this IEnumerable<User> user)
        {
            return user.Select(x => x.ToDTO()).ToList();
        }

        public static IEnumerable<UserWithAlbumsDTO> ToUserWithAlbumsDTOList(this IEnumerable<User> user)
        {
            return user.Select(x => x.ToUserWithAlbumsDTO(x.Albums.ToAlbumWithImagesDTOList())).ToList();
        }

        public static IEnumerable<UserDataDTO> ToUserDataDTOList(this IEnumerable<UserDTO> user)
        {
            return user.Select(x => x.ToUserDataDTO()).ToList();
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