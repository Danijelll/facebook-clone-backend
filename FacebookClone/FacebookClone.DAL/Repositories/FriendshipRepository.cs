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
    public class FriendshipRepository : EfCoreRepository<Friendship>, IFriendshipRepository
    {
        public FriendshipRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { 
        }

        public IEnumerable<Friendship> GetAllUserFriendsByUser(int userId)
        {
            return GetAll().Where(f => f.UserId.Equals(userId));
        }
    }
}
