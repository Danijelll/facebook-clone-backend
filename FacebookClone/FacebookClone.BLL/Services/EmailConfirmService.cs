using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.BLL.Services
{
    public class EmailConfirmService : IEmailConfirmService
    {
        private readonly IEmailConfirmRepository _emailConfirmRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmailConfirmService(IEmailConfirmRepository emailConfirmRepository, IUnitOfWork unitOfWork)
        {
            _emailConfirmRepository = emailConfirmRepository;
            _unitOfWork = unitOfWork;
        }

        public EmailConfirmDTO Add(UserDTO userDTO)
        {
            EmailConfirm emailConfirmResult = userDTO.ToEmailConfirmDTO().ToEntity();
            
            _emailConfirmRepository.Add(emailConfirmResult);

            _unitOfWork.SaveChanges();

            return emailConfirmResult.ToDTO();
        }

        public void Delete(int id)
        {
            if (!ExistsWithID(id))
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            _emailConfirmRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public EmailConfirmDTO GetByEmailHash(string emailHash)
        {
            return _emailConfirmRepository.GetByEmailHash(emailHash)
                .ToDTO();
        }

        public EmailConfirmDTO GetByUserId(int emailConfirmId)
        {
            return _emailConfirmRepository.GetById(emailConfirmId)
                .ToDTO();
        }

        private bool ExistsWithID(int emailConfirmId)
        {
            if (_emailConfirmRepository.GetById(emailConfirmId)?.Id == emailConfirmId)
            {
                return true;
            }
            return false;
        }
    }
}