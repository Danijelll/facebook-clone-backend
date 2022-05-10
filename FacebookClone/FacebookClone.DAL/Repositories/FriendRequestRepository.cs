using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;
using Microsoft.EntityFrameworkCore;

namespace FacebookClone.DAL.Repositories
{
    public class FriendRequestRepository : EfCoreRepository<FriendRequest>, IFriendRequestRepository
    {
        private readonly IUserRepository _userRepository;

        public FriendRequestRepository(IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork)
        {
            _userRepository = userRepository;
        }

        public FriendRequest? GetSentFriendRequest(int userId, int friendId)
        {
            return GetAll().SingleOrDefault(f => f.FirstUserId == userId && f.SecondUserId == friendId);
        }

        public IEnumerable<FriendRequest> GetPendingFriendRequests(int userId, PageFilter pageFilter)
        {
            return GetAll().Where(f => f.SecondUserId == userId)
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                 .Take(pageFilter.PageSize);
        }

        public IEnumerable<FriendRequest> GetAllIncomingFriendRequestsById(int userId, PageFilter pageFilter)
        {
            return GetAll().Where(f => f.SecondUserId == userId && f.IsAccepted == false)
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                 .Take(pageFilter.PageSize);
        }

        public IEnumerable<User> GetAllFriendsWithAlbumsAndImages(int userId)
        {
            return _userRepository.GetAllQueryable()
                                  .Include(u => u.Albums)
                                  .ThenInclude(a => a.Images)
                             
                                  .ToList()
                                  .Where(u =>
                                              GetAll()
                                                .Where(f => (f.FirstUserId == userId || f.SecondUserId == userId) && f.IsAccepted)
                                                .Select(e => e.FirstUserId == userId ? e.SecondUserId : e.FirstUserId)
                                            .Contains(u.Id)
                                  );
                                  
        }


    }
}