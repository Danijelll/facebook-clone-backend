using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;
using Microsoft.EntityFrameworkCore;

namespace FacebookClone.DAL.Repositories
{
    public class AlbumRepository : EfCoreRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Album> GetAllByUserId(int userId, PageFilter pageFilter)
        {
            return GetAll().Where(a => a.UserId == userId)
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                 .Take(pageFilter.PageSize);
        }

        public IEnumerable<Album> GetAllAlbumWithImagesByUserId(int userId, PageFilter pageFilter)
        {
            return _collection.AsNoTracking()
                .Include(a => a.Images)
                .Where(a => a.UserId == userId)
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                .Take(pageFilter.PageSize);
        }

        public List<Album> GetAll(PageFilter pageFilter)
        {
            return GetAll();
        }
    }
}