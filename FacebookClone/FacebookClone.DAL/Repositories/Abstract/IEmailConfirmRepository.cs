using FacebookClone.DAL.Entities;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IEmailConfirmRepository : IRepository<EmailConfirm>
    {
        public EmailConfirm GetByUserId(int userId);

        public EmailConfirm GetByEmailHash(string emailHash);
    }
}