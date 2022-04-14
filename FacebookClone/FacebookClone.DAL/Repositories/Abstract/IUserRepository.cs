using FacebookClone.DAL.Entities;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>, IRepositoryExtension<User>
    {
        public bool UserWithMailExists(string email);

        public bool UserWithUsernameExists(string username);

        public User FindByUsername(string username);
    }
}