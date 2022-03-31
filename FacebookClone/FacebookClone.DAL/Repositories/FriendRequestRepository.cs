using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.DAL.Repositories
{
    public class FriendRequestRepository : EfCoreRepository<FriendRequest>, IFriendRequestRepository
    {
        public FriendRequestRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public FriendRequest GetSentFriendRequest(int userId, int friendId)
        {
            return GetAll().SingleOrDefault(f => f.FirstUserId == userId && f.SecondUserId == friendId);
        }

        public IEnumerable<FriendRequest> GetPendingFriendRequests(int userId)
        {
            return GetAll().Where(f => f.SecondUserId == userId);
        }
    }
}
