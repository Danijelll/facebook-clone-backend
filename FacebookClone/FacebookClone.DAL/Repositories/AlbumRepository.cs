using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories
{
    public class AlbumRepository : EfCoreRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Album> GetAllByUserId(int userId, PageFilter pageFilter)
        {
            return GetAll(pageFilter).Where(a => a.UserId == userId);
        }

        public Album? GetByName(string name)
        {
            return GetAll().Find(a => a.Name == name);
        }
    }
}