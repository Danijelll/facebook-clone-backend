using FacebookClone.BLL.DTO.Message;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class MessageMapper
    {
        public static MessageDTO ToDTO(this Message message)
        {
            return new MessageDTO()
            {
                Id = message.Id,
                SenderId = message.SenderId.ToString(),
                ReceiverId = message.ReceiverId.ToString(),
                Message1 = message.Message1,
                CreatedOn = message.CreatedOn,
                UpdatedOn = message.UpdatedOn,
            };
        }

        public static Message ToEntity(this MessageDTO message)
        {
            return new Message()
            {
                Id = message.Id,
                SenderId = Int32.Parse(message.SenderId),
                ReceiverId = Int32.Parse(message.ReceiverId),
                Message1 = message.Message1,
                CreatedOn = message.CreatedOn,
                UpdatedOn = message.UpdatedOn,
            };
        }
        public static IEnumerable<MessageDTO> ToDTOList(this IEnumerable<Message> message)
        {
            return message.Select(x => x.ToDTO()).ToList();
        }
    }
}