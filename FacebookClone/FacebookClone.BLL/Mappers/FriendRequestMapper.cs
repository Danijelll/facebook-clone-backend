using FacebookClone.BLL.DTO.Friendship;
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
        public static IEnumerable<FriendRequestDTO> ToDTOList(this IEnumerable<FriendRequest> friendRequest)
        {
            return friendRequest.Select(x => x.ToDTO()).ToList();
        }
    }
}