using FacebookClone.BLL.DTO.Comment;
using FacebookClone.BLL.DTO.Comment.Friendship;
using FacebookClone.BLL.DTO.User;
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
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUserService userService, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public CommentDTO Add(CommentDTO commentDTO)
        {
            if (commentDTO == null)
            {
                throw BusinessExceptions.BadRequestException();
            }

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

        public IEnumerable<CommentDTO> GetAll()
        {
            return _commentRepository.GetAll()
                .ToDTOList();
        }

        public IEnumerable<CommentWithUserDataDTO> GetAllByAlbumId(int albumId, int pageSize, int pageNumber)
        {
            if(albumId < 0)
            {
                throw BusinessExceptions.BadRequestException();
            }

            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            IEnumerable<CommentDTO> commentList = _commentRepository.GetAllByAlbumId(albumId, pageFilter)
                .ToDTOList();

            List<CommentWithUserDataDTO> commentWithUserDataDTOList = new List<CommentWithUserDataDTO>();

            foreach (CommentDTO commentDTO in commentList)
            {
                UserDataDTO found = _userService.GetById(commentDTO.UserId);

                CommentWithUserDataDTO commentWithUserDataDTO = commentDTO.ToCommentWithUserDataDTO(found);

                commentWithUserDataDTOList.Add(commentWithUserDataDTO);
            }

            return commentWithUserDataDTOList;
        }

        public IEnumerable<CommentDTO> GetAllByUserId(int userId, int pageSize, int pageNumber)
        {
            PageFilter pageFilter = new PageFilter(pageSize, pageNumber);

            return _commentRepository.GetAllByUserId(userId, pageFilter)
                .ToDTOList();
        }

        public CommentDTO GetById(int id)
        {
            Comment found = _commentRepository.GetById(id);

            if (found != null)
            {
                return found.ToDTO();
            }

            throw BusinessExceptions.EntityDoesNotExistsInDBException;
        }

        public CommentDTO Update(CommentDTO comment)
        {
            Comment found = _commentRepository.GetById(comment.Id);

            if (found != null)
            {
                CommentDTO commentDto = found.ToDTO();
                commentDto.Text = comment.Text;

                Comment updated = _commentRepository.Update(commentDto.ToEntity());

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