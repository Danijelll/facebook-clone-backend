using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IFriendRequestRepository : IRepository<FriendRequest>, IRepositoryExtension<FriendRequest>
    {
        FriendRequest GetSentFriendRequest(int userId, int friendId);

        IEnumerable<User> GetAllFriendsWithAlbumsAndImages(int userId);

        IEnumerable<FriendRequest> GetPendingFriendRequests(int userId, PageFilter pageFilter);

        IEnumerable<FriendRequest> GetAllIncomingFriendRequestsById(int userId, PageFilter pageFilter);
    }
}