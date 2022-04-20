using FacebookClone.BLL.DTO.Friendship;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IFriendshipService
    {
        FriendRequestDTO AddFriendRequest(int currentUserId, int FriendId);

        IEnumerable<FriendRequestDTO> GetAllIncomingFriendRequestsById(int userId, int pageSize, int pageNumber);
    }
}