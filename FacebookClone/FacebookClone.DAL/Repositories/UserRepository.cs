using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Repositories.Interface;

namespace FacebookClone.DAL.Repositories
{
    public class UserRepository : EfCoreRepository<User, FacebookCloneDBContext>, IUserRepository
    {
        public UserRepository(FacebookCloneDBContext context) : base(context)
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