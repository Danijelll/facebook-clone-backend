namespace FacebookClone.BLL.DTO
{
    public class ClaimsDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public int Role { get; set; }
        public bool IsBanned { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}