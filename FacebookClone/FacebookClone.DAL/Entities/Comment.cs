using System;
using System.Collections.Generic;

namespace FacebookClone.DAL.Entities
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Image Image { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
