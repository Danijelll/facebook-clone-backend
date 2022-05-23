using FacebookClone.DAL.Entities.Abstract;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IRepositoryExtension<T> where T : class, IEntity
    {
        List<T> GetAll();

        T Update(T entity);
    }
}