using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;

namespace FacebookClone.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }
        public CommentDTO Add(CommentDTO commentDTO)
        {
            if (!ExistsWithID(commentDTO.Id))
            {
                Comment commentResult = _commentRepository.Add(commentDTO.ToEntity());

                _unitOfWork.SaveChanges();

                return commentResult.ToDTO();
            }

            throw BusinessExceptions.EntityAlreadyExistsInDBEcxeption;
        }

        public void Delete(int id)
        {
            if (ExistsWithID(id))
            {
                _commentRepository.Delete(id);
                _unitOfWork.SaveChanges();
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBEcxeption;
        }

        public IEnumerable<CommentDTO> GetAll()
        {
            return _commentRepository.GetAll()
                .ToDTOList();
        }

        public IEnumerable<CommentDTO> GetAllByImageId(int imageId)
        {
            return _commentRepository.GetAllByImageId(imageId)
                .ToDTOList();
        }

        public IEnumerable<CommentDTO> GetAllByUserId(int userId)
        {
            return _commentRepository.GetAllByUserId(userId)
                .ToDTOList();
        }

        public CommentDTO GetById(int id)
        {
            CommentDTO found = _commentRepository.GetById(id).ToDTO();

            if (found != null)
            {
                return found;
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBEcxeption;
        }

        public CommentDTO Update(CommentDTO commentDTO)
        {
            if (ExistsWithID(commentDTO.Id))
            {
                Comment updated = _commentRepository.Update(commentDTO.ToEntity());

                _unitOfWork.SaveChanges();

                return updated.ToDTO();
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBEcxeption;
        }

        private bool ExistsWithID(int commentId)
        {
            if (_commentRepository.GetById(commentId).Id == commentId)
            {
                return true;
            }
            return false;
        }
    }
}