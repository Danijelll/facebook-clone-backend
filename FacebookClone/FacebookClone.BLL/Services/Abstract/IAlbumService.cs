using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Shared;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IAlbumService
    {
        void Delete(int id);
     
        IEnumerable<AlbumDTO> GetAll(PageFilter pageFilter);

        IEnumerable<AlbumDTO>GetAllByUserId(int userId, PageFilter pageFilter);

        AlbumDTO GetById(int id);

        AlbumDTO Add(AlbumDTO album);

        AlbumDTO Update(AlbumDTO album);
        
    }
}