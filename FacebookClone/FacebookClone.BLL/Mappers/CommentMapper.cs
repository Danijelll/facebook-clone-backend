using FacebookClone.BLL.DTO;
using FacebookClone.DAL.Entities;

namespace FacebookClone.BLL.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO ToDTO(this Comment comment)
        {
            return new CommentDTO()
            {
                Id = comment.Id,
                AlbumId = comment.AlbumId,
                UserId = comment.UserId,
                Text = comment.Text,
                CreatedOn = comment.CreatedOn,
                UpdatedOn = comment.UpdatedOn,
            };
        }

        public static Comment ToEntity(this CommentDTO comment)
        {
            return new Comment()
            {
                Id = comment.Id,
                AlbumId = comment.AlbumId,
                UserId = comment.UserId,
                Text = comment.Text,
                CreatedOn = comment.CreatedOn,
                UpdatedOn = comment.UpdatedOn,
            };
        }

        public static IEnumerable<CommentDTO> ToDTOList(this IEnumerable<Comment> comment)
        {
            return comment.Select(x => x.ToDTO()).ToList();
        }
    }
}