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

        public IEnumerable<Friendship> GetAllUserFriendsByUser(int userId, PageFilter pageFilter)
        {
            return GetAll(pageFilter).Where(f => f.UserId == userId);
        }
    }
}