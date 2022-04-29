using FacebookClone.DAL.Entities.Abstract;
using FacebookClone.DAL.Shared;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IRepositoryExtension<T> where T : class, IEntity
    {
        List<T> GetAll();

        T Update(T entity);
    }
}