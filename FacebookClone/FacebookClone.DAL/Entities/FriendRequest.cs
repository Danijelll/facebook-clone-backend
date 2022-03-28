using System;
using System.Collections.Generic;

namespace FacebookClone.DAL.Entities
{
    public partial class FriendRequest
    {
        public int Id { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
