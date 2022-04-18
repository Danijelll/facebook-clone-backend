using FacebookClone.BLL.DTO.Albums;
using FacebookClone.BLL.DTO.Image;
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

        public static IEnumerable<AlbumDTO> ToDTOList(this IEnumerable<Album> album)
        {
            return album.Select(x => x.ToDTO()).ToList();
        }
    }
}