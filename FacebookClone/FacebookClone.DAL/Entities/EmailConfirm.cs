using FacebookClone.DAL.Entities.Abstract;

namespace FacebookClone.DAL.Entities
{
    public partial class EmailConfirm : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string EmailHash { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual User User { get; set; } = null!;
    }
}