using FacebookClone.BLL.DTO.Friendship;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IFriendshipService
    {
        FriendRequestDTO AddFriendRequest(int currentUserId, int FriendId);

        void DeleteFriendRequest(int currentUserId, int FriendId);

        FriendRequestDTO Update(int currentUserId, int friendId);

        IEnumerable<FriendRequestDTO> GetAllIncomingFriendRequestsById(int userId, int pageSize, int pageNumber);

        Enum CheckFriendRequestStatus(int currentUserId, int friendId);
    }
}