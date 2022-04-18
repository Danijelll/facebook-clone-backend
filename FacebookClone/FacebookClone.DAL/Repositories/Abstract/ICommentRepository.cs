using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface ICommentRepository : IRepository<Comment>, IRepositoryExtension<Comment>
    {
        IEnumerable<Comment> GetAllByImageId(int imageId, PageFilter pageFilter);

        IEnumerable<Comment> GetAllByUserId(int userId, PageFilter pageFilter);
    }
}