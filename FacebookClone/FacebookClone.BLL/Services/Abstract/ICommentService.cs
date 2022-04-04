using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Shared;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface ICommentService
    {
        void Delete(int id);

        IEnumerable<CommentDTO> GetAll(PageFilter pageFilter);

        IEnumerable<CommentDTO> GetAllByUserId(int userId, PageFilter pageFilter);

        IEnumerable<CommentDTO> GetAllByImageId(int imageId, PageFilter pageFilter);

        CommentDTO GetById(int id);

        CommentDTO Add(CommentDTO commentDTO);

        CommentDTO Update(CommentDTO commentDTO);
    }
}