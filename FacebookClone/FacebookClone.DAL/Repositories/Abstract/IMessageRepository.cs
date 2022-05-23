using FacebookClone.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookClone.DAL.Repositories.Abstract
{
    public interface IMessageRepository : IRepository<Message>
    {
        IEnumerable<Message> GetAllByBothUserId(int senderId, int receiverId);

    }
}
