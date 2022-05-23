using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.DAL.Repositories
{
    public class TwoFactorAuthenticatorRepository : EfCoreRepository<TwoFactorAuthentication>
        , ITwoFactorAuthenticatorRepository
    {
        public TwoFactorAuthenticatorRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public TwoFactorAuthentication? GetByUserUsername(string username)
        {
            return GetAll().Find(t => t.Username == username);
        }
    }
}