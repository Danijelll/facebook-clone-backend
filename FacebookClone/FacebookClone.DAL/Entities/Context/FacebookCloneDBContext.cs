using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FacebookClone.DAL.Entities.Context
{
    public partial class FacebookCloneDBContext : DbContext
    {
        private readonly IConfiguration _config;

        public FacebookCloneDBContext(IConfiguration config)
        {
            _config = config;
        }

        public FacebookCloneDBContext(DbContextOptions<FacebookCloneDBContext> options, IConfiguration config)
            : base(options)
        {
            _config = config;
        }

        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<EmailConfirm> EmailConfirms { get; set; } = null!;
        public virtual DbSet<FriendRequest> FriendRequests { get; set; } = null!;
        public virtual DbSet<Friendship> Friendships { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<TwoFactorAuthentication> TwoFactorAuthentications { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config["DBConnectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("album");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_album_user");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Text)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("text");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_comment_album");
            });

            modelBuilder.Entity<EmailConfirm>(entity =>
            {
                entity.ToTable("email_confirm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.EmailHash)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("email_hash");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EmailConfirms)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_email_confirm_user");
            });

            modelBuilder.Entity<FriendRequest>(entity =>
            {
                entity.ToTable("friend_request");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.FirstUserId).HasColumnName("first_user_id");

                entity.Property(e => e.IsAccepted).HasColumnName("is_accepted");

                entity.Property(e => e.SecondUserId).HasColumnName("second_user_id");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });

            modelBuilder.Entity<Friendship>(entity =>
            {
                entity.ToTable("friendship");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.FriendId).HasColumnName("friend_id");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Friendships)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_friendship_user");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("image");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AlbumId).HasColumnName("album_id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("image_url");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK_image_album");
            });

            modelBuilder.Entity<TwoFactorAuthentication>(entity =>
            {
                entity.ToTable("two_factor_authentication");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.TwoFactorCode)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("two_factor_code");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TwoFactorAuthentications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_two_factor_authentication_user");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CoverImage)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("cover_image");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IsBanned).HasColumnName("is_banned");

                entity.Property(e => e.IsEmailConfirmed).HasColumnName("is_email_confirmed");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.ProfileImage)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("profile_image");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }
    }
}