namespace FacebookClone.BLL.DTO.Albums
{
    public class AlbumDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Caption { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}