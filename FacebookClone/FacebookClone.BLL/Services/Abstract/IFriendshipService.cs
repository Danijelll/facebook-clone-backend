using FacebookClone.BLL.DTO.Friendship;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IFriendshipService
    {
        FriendRequestDTO AddFriendRequest(int currentUserId, int FriendId);

        IEnumerable<FriendRequestDTO> GetAllIncomingFriendRequests(int userId, int pageSize, int pageNumber);

        void DeleteFriendRequest(int currentUserId, int FriendId);

        FriendRequestDTO Update(int currentUserId, int friendId);

        Enum CheckFriendRequestStatus(int currentUserId, int friendId);
    }
}