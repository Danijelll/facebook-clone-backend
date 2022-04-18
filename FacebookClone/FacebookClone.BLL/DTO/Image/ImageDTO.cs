namespace FacebookClone.BLL.DTO.Image
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}