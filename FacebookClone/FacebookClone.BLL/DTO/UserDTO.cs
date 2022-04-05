namespace FacebookClone.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }
        public bool IsBanned { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string ProfileImage { get; set; } = null!;
        public string CoverImage { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}