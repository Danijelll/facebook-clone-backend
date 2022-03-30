using FacebookClone.DAL.Entities.Abstract;

namespace FacebookClone.DAL.Repositories.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        List<T> GetAll();

        T? GetById(int id);

        T Add(T entity);

        T Update(T entity);

        T Delete(int id);
    }
}