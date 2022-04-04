using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Shared;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IImageService
    {
        void Delete(int id, string webRootPath);

        IEnumerable<ImageDTO> GetAll(PageFilter pageFilter);

        IEnumerable<ImageDTO> GetAllByAlbumId(int albumId, PageFilter pageFilter);

        ImageDTO GetById(int id);

        ImageDTO Add(ImageDTO imageDTO);

        ImageDTO Update(ImageDTO imageDTO);

    }
}