using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Shared;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface ICommentService
    {
        void Delete(int id);

        IEnumerable<CommentDTO> GetAll(int pageSize, int pageNumber);

        IEnumerable<CommentDTO> GetAllByUserId(int userId, int pageSize, int pageNumber);

        IEnumerable<CommentDTO> GetAllByImageId(int imageId, int pageSize, int pageNumber);

        CommentDTO GetById(int id);

        CommentDTO Add(CommentDTO commentDTO);

        CommentDTO Update(CommentDTO commentDTO);
    }
}