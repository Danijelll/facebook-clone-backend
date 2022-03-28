using FacebookClone.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace FacebookClone.DAL.Entities
{
    public partial class Friendship : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
