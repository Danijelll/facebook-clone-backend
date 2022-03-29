using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Interface;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetAllByImageId (string imageId);
    }
}