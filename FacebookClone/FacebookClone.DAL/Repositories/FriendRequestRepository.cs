using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories
{
    public class FriendRequestRepository : EfCoreRepository<FriendRequest>, IFriendRequestRepository
    {
        public FriendRequestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public FriendRequest? GetSentFriendRequest(int userId, int friendId)
        {
            return GetAll().SingleOrDefault(f => f.FirstUserId == userId && f.SecondUserId == friendId);
        }

        public IEnumerable<FriendRequest> GetPendingFriendRequests(int userId, PageFilter pageFilter)
        {
            return GetAll(pageFilter).Where(f => f.SecondUserId == userId);
        }
    }
}