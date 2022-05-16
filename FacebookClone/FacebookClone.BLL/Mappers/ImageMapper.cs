using FacebookClone.BLL.Constants;
using FacebookClone.BLL.DTO.Image;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class ImageMapper
    {
        public static ImageDTO ToDTO(this Image image, int userId)
        {
            return new ImageDTO()
            {
                Id = image.Id,
                AlbumId = image.AlbumId,
                ImageUrl = $"https://localhost:5001/{ImageConstants.ImageFolder}/{userId}/{image.ImageUrl}",
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
                ImageUrl = image.ImageUrl.Split("/").Last(),
                CreatedOn = image.CreatedOn,
                UpdatedOn = image.UpdatedOn,
            };
        }

        public static IEnumerable<ImageDTO> ToDTOList(this IEnumerable<Image> image, int userId)
        {
            return image.Select(x => x.ToDTO(userId)).ToList();
        }
    }
}