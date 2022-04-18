using FacebookClone.BLL.DTO.Image;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IImageService
    {
        void Delete(int id, string webRootPath);

        IEnumerable<ImageDTO> GetAllByAlbumId(int albumId, int userId);

        ImageDTO Add(ImageDTO imageDTO, int userId);
    }
}