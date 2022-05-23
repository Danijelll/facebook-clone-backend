using FacebookClone.BLL.DTO.Message;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.BLL.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IMessageRepository messageRepository, IUnitOfWork unitOfWork)
        {
            _messageRepository = messageRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<MessageDTO> GetAllByBothUserId(int senderId, int receiverId)
        {
           return _messageRepository.GetAllByBothUserId(senderId, receiverId).ToDTOList();
        }

        public MessageDTO AddMessage(MessageDTO messageDTO)
        {
            if(messageDTO == null)
            {
                throw BusinessExceptions.BadRequestException();
            }

            Message message = _messageRepository.Add(messageDTO.ToEntity());

            _unitOfWork.SaveChanges();

            return message.ToDTO();
        }
    }
}