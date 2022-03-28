using FacebookClone.DAL.Entities.Abstract;

namespace FacebookClone.DAL.Repositories.Interface
{

    public interface IRepository<T, TId> where T : class, IEntity
    {

        List<T> GetAll();

        T Get(TId id);

        T Add(T entity);

        T Update(T entity);

        T Delete(TId id);
    }
}