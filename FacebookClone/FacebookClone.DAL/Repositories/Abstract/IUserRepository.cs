using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>, IRepositoryExtension<User>
    {
        User FindByUsername(string username);

        User GetByEmail(string username);

        IEnumerable<User> SearchByUsername(string username, PageFilter pageFilter);

        IEnumerable<User> SearchByUsernameWithBanned(string username, PageFilter pageFilter);

        IQueryable<User> GetAllQueryable();
    }
}