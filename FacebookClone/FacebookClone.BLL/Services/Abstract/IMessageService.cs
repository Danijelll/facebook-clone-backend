using FacebookClone.BLL.DTO.Message;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface IMessageService
    {
        MessageDTO SendMessage(MessageDTO messageDTO);

        IEnumerable<MessageDTO> GetAllByBothUserId(int senderId, int receiverId);
    }
}