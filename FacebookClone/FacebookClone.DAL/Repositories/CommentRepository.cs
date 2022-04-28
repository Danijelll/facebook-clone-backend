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

        public IEnumerable<Comment> GetAllByAlbumId(int albumId, PageFilter pageFilter)
        {
            return GetAll(pageFilter).Where(c => c.AlbumId.Equals(albumId));
        }

        public IEnumerable<Comment> GetAllByUserId(int userId, PageFilter pageFilter)
        {
            return GetAll(pageFilter).Where(c => c.UserId.Equals(userId));
        }
    }
}