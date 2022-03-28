using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User, int>
    {
        public bool UserWithMailExists(string email);
        public bool UserWithUsernameExists(string username);
        public User FindByUsername(string username);
    }
}
