using FacebookClone.BLL.DTO.Albums;
using FacebookClone.BLL.DTO.Friendship;
using FacebookClone.BLL.DTO.User;
using FacebookClone.DAL.Entities;

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