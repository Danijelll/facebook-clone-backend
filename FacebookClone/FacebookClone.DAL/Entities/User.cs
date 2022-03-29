using FacebookClone.DAL.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace FacebookClone.DAL.Entities
{
    public partial class User : IEntity
    {
        public User()
        {
            Albums = new HashSet<Album>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsEmailConfirmed { get; set; }
        public string ProfileImage { get; set; } = null!;
        public string CoverImage { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
