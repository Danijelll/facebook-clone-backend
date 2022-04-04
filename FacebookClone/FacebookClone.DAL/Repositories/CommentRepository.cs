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

        public IEnumerable<Comment> GetAllByImageId(int imageId, PageFilter pageFilter)
        {
            return GetAll(pageFilter).Where(c => c.ImageId.Equals(imageId));
        }

        public IEnumerable<Comment> GetAllByUserId(int userId, PageFilter pageFilter)
        {
            return GetAll(pageFilter).Where(c => c.UserId.Equals(userId));
        }
    }
}