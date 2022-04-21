using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

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
            return GetAll().Where(u => u.Username.Contains(username) && u.IsBanned == false && u.IsEmailConfirmed == true);
        }
    }
}