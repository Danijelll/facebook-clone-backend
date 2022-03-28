using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Interface;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IAlbumRepository : IRepository<Album, int>
    {
        public IEnumerable<Album> GetByUserId(int userId);
    }
}