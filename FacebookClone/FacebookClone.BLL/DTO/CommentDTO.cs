namespace FacebookClone.BLL.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}