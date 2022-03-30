using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
