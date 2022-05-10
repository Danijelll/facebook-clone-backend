using FacebookClone.BLL.DTO.Image;
using FacebookClone.BLL.DTO.User;

namespace FacebookClone.BLL.DTO.Album
{
    public class AlbumWithImagesWithUserDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Caption { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public IEnumerable<ImageDTO> Images { get; set; }
        public IEnumerable<UserDataDTO> Users { get; set; }
    }
}