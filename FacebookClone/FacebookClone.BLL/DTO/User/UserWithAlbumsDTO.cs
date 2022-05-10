using FacebookClone.BLL.DTO.Albums;
using FacebookClone.BLL.Enums;

namespace FacebookClone.BLL.DTO.User
{
    public class UserWithAlbumsDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Roles Role { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string ProfileImage { get; set; } = null!;
        public string CoverImage { get; set; } = null!;
        public IEnumerable<AlbumWithImagesDTO> Albums { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}