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

        public bool UserWithMailExists(string email)
        {
            return GetAll().Exists(u => u.Email == email);
        }

        public bool UserWithUsernameExists(string username)
        {
            return GetAll().Exists(u => u.Username == username);
        }
    }
}