using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Repositories.Interface;

namespace FacebookClone.DAL.Repositories
{
    public class AlbumRepository : EfCoreRepository<Album, FacebookCloneDBContext>, IAlbumRepository
    {
        public AlbumRepository(FacebookCloneDBContext context) : base(context)
        {
        }

        public IEnumerable<Album> GetAllByUserId(int userId)
        {
            return Context.Albums.Where(a => a.UserId == userId);
        }
    }
}