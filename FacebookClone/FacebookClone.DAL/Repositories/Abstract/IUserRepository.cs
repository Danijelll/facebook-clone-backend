using FacebookClone.DAL.Entities;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>, IRepositoryExtension<User>
    {
        public User FindByUsername(string username);

        IEnumerable<User> SearchByUsername(string username);

        IEnumerable<User> SearchByUsernameWithBanned(string username);

        IQueryable<User> GetAllQueryable();
    }
}