using FacebookClone.DAL.Entities.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        List<T> GetAll(PageFilter pageFilter);

        T? GetById(int id);

        T Add(T entity);

        T Update(T entity);

        T Delete(int id);
    }
}