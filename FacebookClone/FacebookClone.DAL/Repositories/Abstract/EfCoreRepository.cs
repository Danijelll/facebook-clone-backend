using FacebookClone.DAL.Entities.Abstract;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FacebookClone.DAL.Repositories.Interface
{
    public abstract class EfCoreRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly FacebookCloneDBContext _context;
        protected readonly DbSet<TEntity> _collection;

        public EfCoreRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
            _collection = _context.Set<TEntity>();

        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.UpdatedOn = DateTime.UtcNow;

            _collection.Add(entity);

            return entity;
        }

        public TEntity Delete(int id)
        {
            TEntity entity = _collection.First(e => e.Id == id);

            _collection.Remove(entity);

            return entity;
        }

        public TEntity? Get(int id)
        {
            return _collection.AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public List<TEntity> GetAll()
        {
            return _collection.AsNoTracking()
                 .ToList();
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedOn = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}