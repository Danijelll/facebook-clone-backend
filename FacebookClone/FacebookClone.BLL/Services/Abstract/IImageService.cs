using FacebookClone.BLL.DTO;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IImageService
    {
        void Delete(int id, string webRootPath);

        IEnumerable<ImageDTO> GetAll();

        IEnumerable<ImageDTO> GetAllByAlbumId(int albumId);

        ImageDTO GetById(int id);

        ImageDTO Add(ImageDTO imageDTO);

        ImageDTO Update(ImageDTO imageDTO);

    }
}