using FacebookClone.BLL.DTO.Friendship;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IFriendshipService
    {
        IEnumerable<FriendRequestDTO> GetAllIncomingFriendRequestsById(int userId, int pageSize, int pageNumber);
    }
}