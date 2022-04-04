using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IFriendshipRepository : IRepository<Friendship>
    {
        public IEnumerable<Friendship> GetAllUserFriendsByUser(int userId, PageFilter pageFilter);
    }
}