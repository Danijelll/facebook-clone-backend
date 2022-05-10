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

        public IEnumerable<User> SearchByUsername(string username)
        {
            return GetAll().Where(u => u.Username.ToLower().Contains(username.ToLower()) && u.IsBanned == false && u.IsEmailConfirmed == true);
        }
        public IQueryable<User> GetAllQueryable()
        {
            return _collection.AsNoTracking().Where(u => !u.IsBanned && u.IsEmailConfirmed);
        }
    }
}