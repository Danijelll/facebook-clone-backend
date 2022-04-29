using FacebookClone.BLL.DTO.Comment;
using FacebookClone.BLL.DTO.Comment.Friendship;
using FacebookClone.BLL.DTO.User;
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

        public static CommentWithUserDataDTO ToCommentWithUserDataDTO(this CommentDTO comment, UserDataDTO user)
        {
            return new CommentWithUserDataDTO()
            {
                Id = comment.Id,
                AlbumId = comment.AlbumId,
                UserId = user.Id,
                Text = comment.Text,
                Username = user.Username,
                ProfileImage = user.ProfileImage,
                UpdatedOn = comment.UpdatedOn,
                CreatedOn = comment.CreatedOn,
            };
        }

        public static IEnumerable<CommentDTO> ToDTOList(this IEnumerable<Comment> comment)
        {
            return comment.Select(x => x.ToDTO()).ToList();
        }
    }
}