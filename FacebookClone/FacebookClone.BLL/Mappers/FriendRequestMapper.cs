using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class FriendRequestMapper
    {
        public static FriendRequestDTO ToDTO(this FriendRequest friendRequest)
        {
            return new FriendRequestDTO()
            {
                Id = friendRequest.Id,
                FirstUserId = friendRequest.FirstUserId,
                SecondUserId = friendRequest.SecondUserId,
                IsAccepted = friendRequest.IsAccepted,
                CreatedOn = friendRequest.CreatedOn,
                UpdatedOn = friendRequest.UpdatedOn,
            };
        }

        public static FriendRequest ToEntity(this FriendRequestDTO friendRequest)
        {
            return new FriendRequest()
            {
                Id = friendRequest.Id,
                FirstUserId = friendRequest.FirstUserId,
                SecondUserId = friendRequest.SecondUserId,
                IsAccepted = friendRequest.IsAccepted,
                CreatedOn = friendRequest.CreatedOn,
                UpdatedOn = friendRequest.UpdatedOn,
            };
        }
    }
}