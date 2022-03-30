using FacebookClone.DAL.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        public void SaveChanges();

        public void Dispose();

        public FacebookCloneDBContext GetContext();
    }
}
