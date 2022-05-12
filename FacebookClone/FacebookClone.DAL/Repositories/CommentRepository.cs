using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories
{
    public class CommentRepository : EfCoreRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Comment> GetAllByAlbumId(int albumId, PageFilter pageFilter)
        {
            return GetAll().Where(c => c.AlbumId == albumId)
                .OrderByDescending(c => c.CreatedOn)
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