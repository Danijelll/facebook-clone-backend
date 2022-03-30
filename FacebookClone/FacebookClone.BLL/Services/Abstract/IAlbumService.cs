using FacebookClone.BLL.DTO;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IAlbumService
    {
        void Delete(int id);
     
        IEnumerable<AlbumDTO> GetAll();

        IEnumerable<AlbumDTO>GetAllByUserId(int userId);

        AlbumDTO GetById(int id);

        AlbumDTO Add(AlbumDTO album);

        AlbumDTO Update(AlbumDTO album);
        
    }
}