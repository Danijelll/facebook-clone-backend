using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IAlbumRepository : IRepository<Album>, IRepositoryExtension<Album>
    {
        public IEnumerable<Album> GetAllByUserId(int userId, PageFilter pageFilter);

        public Album GetByName(string name);
    }
}