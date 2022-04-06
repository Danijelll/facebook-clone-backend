namespace FacebookClone.BLL.DTO
{
    public class EmailConfirmDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmailHash { get; set; } = null!;
    }
}