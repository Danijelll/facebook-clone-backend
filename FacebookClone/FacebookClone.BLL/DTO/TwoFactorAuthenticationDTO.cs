namespace FacebookClone.BLL.DTO
{
    public class TwoFactorAuthenticationDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TwoFactorCode { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}