using FacebookClone.DAL.Entities;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface ITwoFactorAuthenticatorRepository : IRepository<TwoFactorAuthentication>
    {
        TwoFactorAuthentication GetByUserEmail(string email);
    }
}