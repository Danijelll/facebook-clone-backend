namespace FacebookClone.BLL.DTO.Auth
{
    public class EmailConfirmDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmailHash { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}