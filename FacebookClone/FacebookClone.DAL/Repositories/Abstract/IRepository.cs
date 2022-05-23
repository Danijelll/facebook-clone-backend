using FacebookClone.DAL.Entities.Abstract;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : class, IEntity
    {
        T? GetById(int id);

        T Add(T entity);

        T Delete(int id);
    }
}