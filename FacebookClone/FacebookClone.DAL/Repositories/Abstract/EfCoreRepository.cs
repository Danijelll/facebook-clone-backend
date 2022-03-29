using FacebookClone.DAL.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FacebookClone.DAL.Repositories.Interface
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
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

        public TEntity Delete(int id)
        {
            TEntity entity = Context.Set<TEntity>()
                .Find(id);

            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();

            return entity;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
        }

        public List<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsNoTracking()
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