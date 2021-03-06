using FacebookClone.DAL.Entities.Abstract;

namespace FacebookClone.DAL.Entities
{
    public partial class Image : IEntity
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Album Album { get; set; } = null!;
    }
}