using FacebookClone.BLL.DTO;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface ICommentService
    {
        void Delete(int id);

        IEnumerable<CommentDTO> GetAll();

        IEnumerable<CommentDTO> GetAllByUserId(int userId);

        IEnumerable<CommentDTO> GetAllByImageId(int imageId);

        CommentDTO GetById(int id);

        CommentDTO Add(CommentDTO commentDTO);

        CommentDTO Update(CommentDTO commentDTO);
    }
}