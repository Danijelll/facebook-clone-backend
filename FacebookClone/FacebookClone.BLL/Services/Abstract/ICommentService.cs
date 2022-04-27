using FacebookClone.BLL.DTO.Comment.Friendship;

namespace FacebookClone.BLL.Services.Abstract
{
    public interface ICommentService
    {
        void Delete(int id);

        IEnumerable<CommentDTO> GetAll(int pageSize, int pageNumber);

        IEnumerable<CommentDTO> GetAllByUserId(int userId, int pageSize, int pageNumber);

        IEnumerable<CommentDTO> GetAllByAlbumId(int albumId, int pageSize, int pageNumber);

        CommentDTO GetById(int id);

        CommentDTO Add(CommentDTO commentDTO);

        CommentDTO Update(CommentDTO commentDTO);
    }
}