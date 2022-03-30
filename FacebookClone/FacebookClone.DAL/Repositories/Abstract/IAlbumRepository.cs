using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Interface;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IAlbumRepository : IRepository<Album>
    {
        public IEnumerable<Album> GetAllByUserId(int userId);

        public Album GetByName(string name);
    }
}