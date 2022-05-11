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
        public IEnumerable<Album> GetAllFriendsWithAlbumsWithImages(int userId, PageFilter pageFilter)
        {
            return _context.Albums.AsNoTracking()
                .Include(a => a.Images)
                .Include(a => a.User)
                .OrderByDescending(a => a.CreatedOn)
                .ToList()
                .Where(a => _context.FriendRequests
                                .Where(f => (f.FirstUserId == userId || f.SecondUserId == userId) && f.IsAccepted)
                                .Select(e => e.FirstUserId == userId ? e.SecondUserId : e.FirstUserId)
                            .Contains(a.UserId)
                )
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                .Take(pageFilter.PageSize);
        }
    }
}