using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.DAL.Repositories.Interface {
    public interface IRepository<T, TId> where T : class
    {
        List<T> GetAll();
        T Get(TId id);
        T Add(T entity);
        T Update(T entity);
        T Delete(TId id);
    }
}
