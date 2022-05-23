using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.DAL.Repositories
{
    public class MessageRepository : EfCoreRepository<Message>, IMessageRepository
    {
        public MessageRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IEnumerable<Message> GetAllByBothUserId(int senderId, int receiverId)
        {
            return GetAll().Where(m =>
                (m.SenderId == senderId || m.ReceiverId == senderId) &&
                (m.SenderId == receiverId || m.ReceiverId == receiverId));
        }
    }
}