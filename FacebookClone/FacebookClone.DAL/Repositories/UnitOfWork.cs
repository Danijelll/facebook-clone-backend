using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FacebookCloneDBContext _context;

        public UnitOfWork(FacebookCloneDBContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public FacebookCloneDBContext GetContext()
        {
            return _context;
        }
    }
}