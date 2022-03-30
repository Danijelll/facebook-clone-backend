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

        public IEnumerable<Comment> GetAllByImageId(string imageId)
        {
            return GetAll().Where(c => c.ImageId.Equals(imageId));
        }
    }
}