using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;
using Microsoft.EntityFrameworkCore;

namespace FacebookClone.DAL.Repositories
{
    public class CommentRepository : EfCoreRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Comment> GetAll(PageFilter pageFilter)
        {
            return GetAll();
        }

        public IEnumerable<Comment> GetAllByAlbumId(int albumId, PageFilter pageFilter)
        {
            return GetAll().Where(c => c.AlbumId == albumId)
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                 .Take(pageFilter.PageSize);
        }

        public IEnumerable<Comment> GetAllByUserId(int userId, PageFilter pageFilter)
        {
            return GetAll().Where(c => c.UserId == userId)
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                 .Take(pageFilter.PageSize);
        }
    }
}