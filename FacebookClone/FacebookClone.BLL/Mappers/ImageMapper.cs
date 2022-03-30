using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class ImageMapper
    {
        public static ImageDTO ToDTO(this Image image)
        {
            return new ImageDTO()
            {
                Id = image.Id,
                AlbumId = image.AlbumId,
                Name = image.Name,
                ImageUrl = $"http://localhost:5000/{ImageConstants.ImageFolder}/{image.AlbumId}/{image.ImageUrl}",
                CreatedOn = image.CreatedOn,
                UpdatedOn = image.UpdatedOn,
            };
        }

        public static Image ToEntity(this ImageDTO image)
        {
            return new Image()
            {
                Id = image.Id,
                AlbumId = image.AlbumId,
                Name = image.Name,
                ImageUrl = image.ImageUrl.Split("/").Last(),
                CreatedOn = image.CreatedOn,
                UpdatedOn = image.UpdatedOn,
            };
        }
    }
}