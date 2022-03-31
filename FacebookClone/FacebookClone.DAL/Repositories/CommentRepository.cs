using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Repositories.Interface;

namespace FacebookClone.DAL.Repositories
{
    public class CommentRepository : EfCoreRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Comment> GetAllByImageId(int imageId)
        {
            return GetAll().Where(c => c.ImageId.Equals(imageId));
        }

        public IEnumerable<Comment> GetAllByUserId(int userId)
        {
            return GetAll().Where(c => c.UserId.Equals(userId));
        }
    }
}