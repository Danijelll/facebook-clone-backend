using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.DAL.Repositories
{
    public class EmailConfirmRepository : EfCoreRepository<EmailConfirm>, IEmailConfirmRepository
    {
        public EmailConfirmRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public EmailConfirm? GetByEmailHash(string emailHash)
        {
            return GetAll().Find(e => e.EmailHash == emailHash);
        }

        public EmailConfirm? GetByUserId(int userId)
        {
            return GetAll().Find(e => e.UserId == userId);
        }
    }
}