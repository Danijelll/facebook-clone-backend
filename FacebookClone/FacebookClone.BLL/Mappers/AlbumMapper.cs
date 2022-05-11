using FacebookClone.BLL.DTO.Album;
using FacebookClone.BLL.DTO.Albums;
using FacebookClone.BLL.DTO.Image;
using FacebookClone.BLL.DTO.User;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class AlbumMapper
    {
        public static AlbumDTO ToDTO(this Album album)
        {
            return new AlbumDTO()
            {
                Id = album.Id,
                UserId = album.UserId,
                Caption = album.Caption,
                CreatedOn = album.CreatedOn,
                UpdatedOn = album.UpdatedOn,
            };
        }

        public static Album ToEntity(this AlbumDTO album)
        {
            return new Album()
            {
                Id = album.Id,
                UserId = album.UserId,
                Caption = album.Caption,
                CreatedOn = album.CreatedOn,
                UpdatedOn = album.UpdatedOn,
            };
        }

        public static AlbumDTO ToAlbumDTO(this Album album)
        {
            return new AlbumDTO()
            {
                Id = album.Id,
                UserId = album.UserId,
                Caption = album.Caption,
                CreatedOn = album.CreatedOn,
                UpdatedOn = album.UpdatedOn,
            };
        }

        public static AlbumWithImagesDTO ToAlbumWithImagesDTO(this AlbumDTO album, IList<ImageDTO> images)
        {
            return new AlbumWithImagesDTO()
            {
                Id = album.Id,
                UserId = album.UserId,
                Caption = album.Caption,
                CreatedOn = album.CreatedOn,
                UpdatedOn = album.UpdatedOn,
                Images = images
            };
        }

        public static AlbumWithImagesDTO ToAlbumWithImagesDTO(this Album album, IList<ImageDTO> images)
        {
            return new AlbumWithImagesDTO()
            {
                Id = album.Id,
                UserId = album.UserId,
                Caption = album.Caption,
                CreatedOn = album.CreatedOn,
                UpdatedOn = album.UpdatedOn,
                Images = images
            };
        }

        public static AlbumDTO ToBaseDTO(this AlbumWithImagesDTO album)
        {
            return new AlbumDTO()
            {
                Id = album.Id,
                UserId = album.UserId,
                Caption = album.Caption,
                CreatedOn = album.CreatedOn,
                UpdatedOn = album.UpdatedOn,
            };
        }

        public static AlbumWithImagesDTO ToAlbumWithImagesDTO(this Album album)
        {
            return new AlbumWithImagesDTO()
            {
                Id = album.Id,
                UserId = album.UserId,
                Caption = album.Caption,
                Images = album.Images.ToDTOList(album.UserId).ToList(),
                CreatedOn = album.CreatedOn,
                UpdatedOn = album.UpdatedOn,
            };
        }

        public static AlbumWithImagesWithUserDTO ToAlbumWithImagesWithUserDTO(this Album album, IEnumerable<ImageDTO> images, UserDataDTO user)
        {
            return new AlbumWithImagesWithUserDTO()
            {
                Id = album.Id,
                UserId = album.UserId,
                Caption = album.Caption,
                CreatedOn = album.CreatedOn,
                UpdatedOn = album.UpdatedOn,
                Images = images,
                Username = user.Username,
                UserProfileImageUrl = user.ProfileImage,
            };
        }

        public static IEnumerable<AlbumWithImagesWithUserDTO> ToAlbumWithImagesWithUserDTOList(this IEnumerable<Album> albums)
        {
            return albums.Select(x => x.ToAlbumWithImagesWithUserDTO(x.Images.ToDTOList(x.UserId),x.User.ToDTO().ToUserDataDTO()));
        }

        public static IEnumerable<AlbumDTO> ToDTOList(this IEnumerable<Album> album)
        {
            return album.Select(x => x.ToDTO()).ToList();
        }

        public static IEnumerable<AlbumWithImagesDTO> ToAlbumWithImagesDTOList(this IEnumerable<Album> album)
        {
            return album.Select(x => x.ToAlbumWithImagesDTO());
        }
    }
}