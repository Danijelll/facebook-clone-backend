using FacebookClone.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace FacebookClone.DAL.Entities
{
    public partial class Album : IEntity
    {
        public Album()
        {
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Image> Images { get; set; }
    }
}
