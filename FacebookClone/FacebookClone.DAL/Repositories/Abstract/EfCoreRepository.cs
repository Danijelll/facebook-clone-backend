using FacebookClone.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FacebookClone.DAL.Repositories.Interface 
{

    public abstract class EfCoreRepository<TEntity, TId, TContext> : IRepository<TEntity, TId>
        where TEntity : class, IEntity
        where TContext : DbContext 
        
        {

        protected readonly TContext Context;

        public EfCoreRepository(TContext context) 
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.UpdatedOn = DateTime.UtcNow;

            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();

            return entity;

        }

        public TEntity Delete(TId id) 
        {
            TEntity entity = Context.Set<TEntity>()
                .Find(id);

            if (entity == null)
            {
                return null;
            }

            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();

            return entity;
        }

        public TEntity Get(TId id)
        {
            return Context.Set<TEntity>()
                .Find(id);
        }

        public List<TEntity> GetAll()
        {
           return Context.Set<TEntity>()
                .ToList();
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedOn = DateTime.UtcNow;

            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();

            return entity;
        }
    }
}