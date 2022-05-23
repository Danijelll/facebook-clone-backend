using FacebookClone.DAL.Entities.Abstract;

namespace FacebookClone.DAL.Entities
{
    public partial class Message : IEntity
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message1 { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}