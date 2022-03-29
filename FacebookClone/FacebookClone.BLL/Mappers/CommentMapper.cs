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
                ImageId = comment.ImageId,
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
                ImageId = comment.ImageId,
                UserId = comment.UserId,
                Text = comment.Text,
                CreatedOn = comment.CreatedOn,
                UpdatedOn = comment.UpdatedOn,
            };
        }
    }
}