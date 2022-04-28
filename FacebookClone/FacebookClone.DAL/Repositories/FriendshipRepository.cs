using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories
{
    public class FriendshipRepository : EfCoreRepository<Friendship>, IFriendshipRepository
    {
        public FriendshipRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Friendship> GetAll(PageFilter pageFilter)
        {
            return GetAll();
        }

        public IEnumerable<Friendship> GetAllUserFriendsByUser(int userId, PageFilter pageFilter)
        {
            return GetAll().Where(f => f.UserId == userId)
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                 .Take(pageFilter.PageSize);
        }

        public Friendship GetFriendshipByFirstAndSecondUserId(int firstUserId, int secondUserId)
        {
            return GetAll().Find(f => f.UserId == firstUserId && f.FriendId == secondUserId);
        }
    }
}