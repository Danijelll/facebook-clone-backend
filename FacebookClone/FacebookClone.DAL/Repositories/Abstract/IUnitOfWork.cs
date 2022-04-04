using FacebookClone.DAL.Entities.Context;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        public void SaveChanges();

        public void Dispose();

        public FacebookCloneDBContext GetContext();
    }
}