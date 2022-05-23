using FacebookClone.DAL.Entities.Abstract;

namespace FacebookClone.DAL.Entities
{
    public partial class TwoFactorAuthentication : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string TwoFactorCode { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}