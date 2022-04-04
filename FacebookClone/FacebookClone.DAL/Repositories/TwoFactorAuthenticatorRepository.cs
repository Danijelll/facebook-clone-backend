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

        public TwoFactorAuthentication? GetTwoFactorAuthenticationByUserId(int userId)
        {
            return GetAll().Find(t => t.UserId == userId);
        }
    }
}