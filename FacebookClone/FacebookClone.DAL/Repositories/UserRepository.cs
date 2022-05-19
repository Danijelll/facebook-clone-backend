using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;
using Microsoft.EntityFrameworkCore;

namespace FacebookClone.DAL.Repositories
{
    public class UserRepository : EfCoreRepository<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public User FindByUsername(string username)
        {
            return GetAll().Find(u => u.Username == username);
        }

        public User GetByEmail(string email)
        {
            return GetAll().Find(u => u.Email == email);
        }

        public IEnumerable<User> SearchByUsername(string username, PageFilter pageFilter)
        {
            return GetAll().Where(u => u.Username.ToLower().Contains(username.ToLower()) && u.IsBanned == false && u.IsEmailConfirmed == true)
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                 .Take(pageFilter.PageSize);
        }

        public IEnumerable<User> SearchByUsernameWithBanned(string username, PageFilter pageFilter)
        {
            return GetAll().Where(u => u.Username.ToLower().Contains(username.ToLower()) && u.IsEmailConfirmed == true)
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                 .Take(pageFilter.PageSize);
        }
        public IQueryable<User> GetAllQueryable()
        {
            return _collection.AsNoTracking().Where(u => !u.IsBanned && u.IsEmailConfirmed);
        }

        public IEnumerable<User> GetAllFriends(int userId, PageFilter pageFilter)
        {
            return _context.Users.AsNoTracking()
                .Where(a => !a.IsBanned)
                .ToList()
                .Where(a => _context.FriendRequests
                                .Where(f => (f.FirstUserId == userId || f.SecondUserId == userId) && f.IsAccepted)
                                .Select(e => e.FirstUserId == userId ? e.SecondUserId : e.FirstUserId)
                            .Contains(a.Id)
                )
                .Skip(pageFilter.PageNumber * pageFilter.PageSize)
                .Take(pageFilter.PageSize);
        }
    }
}