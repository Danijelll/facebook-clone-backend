using FacebookClone.BLL.DTO;
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
                Name = album.Name,
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
                Name = album.Name,
                CreatedOn = album.CreatedOn,
                UpdatedOn = album.UpdatedOn,
            };
        }
    }
}