namespace FacebookClone.BLL.DTO.Auth
{
    public class TwoFactorAuthenticationDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string TwoFactorCode { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}