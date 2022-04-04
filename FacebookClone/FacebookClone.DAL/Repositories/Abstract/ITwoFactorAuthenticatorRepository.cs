using FacebookClone.DAL.Entities;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface ITwoFactorAuthenticatorRepository : IRepository<TwoFactorAuthentication>
    {
        public TwoFactorAuthentication GetTwoFactorAuthenticationByUserId(int userId);
    }
}