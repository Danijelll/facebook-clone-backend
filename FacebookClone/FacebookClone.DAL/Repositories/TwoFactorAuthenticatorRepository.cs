using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Entities.Context;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.DAL.Repositories
{
    public class TwoFactorAuthenticatorRepository : EfCoreRepository<TwoFactorAuthentication, FacebookCloneDBContext>
        , ITwoFactorAuthenticatorRepository
    {
        public TwoFactorAuthenticatorRepository(FacebookCloneDBContext context) : base(context)
        {
        }

        public TwoFactorAuthentication GetTwoFactorAuthenticationByUserId(int userId)
        {
            return GetAll().Find(t => t.UserId == userId);
        }
    }
}
