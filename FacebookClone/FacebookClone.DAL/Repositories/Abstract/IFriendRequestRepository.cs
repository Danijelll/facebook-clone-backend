using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IFriendRequestRepository : IRepository<FriendRequest>, IRepositoryExtension<FriendRequest>
    {
        public FriendRequest GetSentFriendRequest(int userId, int friendId);

        public IEnumerable<FriendRequest> GetPendingFriendRequests(int userId, PageFilter pageFilter);
    }
}