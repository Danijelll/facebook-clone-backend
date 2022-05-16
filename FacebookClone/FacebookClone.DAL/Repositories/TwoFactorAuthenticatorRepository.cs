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

        public TwoFactorAuthentication? GetByUserEmail(string email)
        {
            return GetAll().Find(t => t.Username == email);
        }
    }
}