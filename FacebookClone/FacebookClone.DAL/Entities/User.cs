using FacebookClone.DAL.Entities.Abstract;

namespace FacebookClone.DAL.Entities
{
    public partial class User : IEntity
    {
        public User()
        {
            Albums = new HashSet<Album>();
            Comments = new HashSet<Comment>();
            Friendships = new HashSet<Friendship>();
            TwoFactorAuthentications = new HashSet<TwoFactorAuthentication>();
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
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Friendship> Friendships { get; set; }
        public virtual ICollection<TwoFactorAuthentication> TwoFactorAuthentications { get; set; }
    }
}