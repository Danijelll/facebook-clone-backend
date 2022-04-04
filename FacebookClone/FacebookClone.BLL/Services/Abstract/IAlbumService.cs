using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Shared;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IAlbumService
    {
        void Delete(int id);
     
        IEnumerable<AlbumDTO> GetAll(int pageSize, int pageNumber);

        IEnumerable<AlbumDTO>GetAllByUserId(int userId, int pageSize, int pageNumber);

        AlbumDTO GetById(int id);

        AlbumDTO Add(AlbumDTO album);

        AlbumDTO Update(AlbumDTO album);
        
    }
}