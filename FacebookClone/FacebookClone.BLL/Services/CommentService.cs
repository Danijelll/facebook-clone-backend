using FacebookClone.BLL.DTO;
using FacebookClone.BLL.Mappers;
using FacebookClone.BLL.Model;
using FacebookClone.BLL.Services.Abstract;
using FacebookClone.DAL.Entities;
using FacebookClone.DAL.Repositories.Abstract;
using FacebookClone.DAL.Shared;

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
            Comment commentResult = _commentRepository.Add(commentDTO.ToEntity());

            _unitOfWork.SaveChanges();

            return commentResult.ToDTO();
        }

        public void Delete(int id)
        {
            if (!ExistsWithID(id))
            {
                throw BusinessExceptions.EntityDoesNotExistsInDBException;
            }

            _commentRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<CommentDTO> GetAll(PageFilter pageFilter)
        {
            return _commentRepository.GetAll(pageFilter)
                .ToDTOList();
        }

        public IEnumerable<CommentDTO> GetAllByImageId(int imageId, PageFilter pageFilter)
        {
            return _commentRepository.GetAllByImageId(imageId, pageFilter)
                .ToDTOList();
        }

        public IEnumerable<CommentDTO> GetAllByUserId(int userId, PageFilter pageFilter)
        {
            return _commentRepository.GetAllByUserId(userId, pageFilter)
                .ToDTOList();
        }

        public CommentDTO GetById(int id)
        {
            CommentDTO found = _commentRepository.GetById(id).ToDTO();

            if (found != null)
            {
                return found;
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
        }

        public CommentDTO Update(CommentDTO commentDTO)
        {
            if (ExistsWithID(commentDTO.Id))
            {
                Comment updated = _commentRepository.Update(commentDTO.ToEntity());

                _unitOfWork.SaveChanges();

                return updated.ToDTO();
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
        }

        private bool ExistsWithID(int commentId)
        {
            if (_commentRepository.GetById(commentId)?.Id == commentId)
            {
                return true;
            }
            return false;
        }
    }
}