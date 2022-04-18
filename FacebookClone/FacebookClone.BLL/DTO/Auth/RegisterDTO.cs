using FacebookClone.BLL.Constants;
using FacebookClone.BLL.Enums;

namespace FacebookClone.BLL.DTO.Auth
{
    public class RegisterDTO
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ProfileImage { get; set; } = ImageConstants.DefaultImageName;
        public string CoverImage { get; set; } = ImageConstants.DefaultImageName;
        public Roles Role { get; set; } = Roles.User;
        public bool IsBanned { get; set; } = false;
        public bool IsEmailConfirmed { get; set; } = false;
    }
}