using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IAlbumRepository : IRepository<Album>, IRepositoryExtension<Album>
    {
         IEnumerable<Album> GetAllByUserId(int userId, PageFilter pageFilter);

         IEnumerable<Album> GetAllAlbumWithImagesByUserId(int userId, PageFilter pageFilter);
    }
}