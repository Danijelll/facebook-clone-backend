﻿// <auto-generated />
using System;
using FacebookClone.DAL.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FacebookClone.DAL.Migrations
{
    [DbContext(typeof(FacebookCloneDBContext))]
    partial class FacebookCloneDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FacebookClone.DAL.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("caption");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("created_on");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_on");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("album", "dbo");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int")
                        .HasColumnName("album_id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("created_on");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("text");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_on");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("comment", "dbo");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.EmailConfirm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("created_on");

                    b.Property<string>("EmailHash")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("email_hash");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_on");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("email_confirm", "dbo");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.FriendRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("created_on");

                    b.Property<int>("FirstUserId")
                        .HasColumnType("int")
                        .HasColumnName("first_user_id");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit")
                        .HasColumnName("is_accepted");

                    b.Property<int>("SecondUserId")
                        .HasColumnType("int")
                        .HasColumnName("second_user_id");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.ToTable("friend_request", "dbo");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AlbumId")
                        .HasColumnType("int")
                        .HasColumnName("album_id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("created_on");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("image_url");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_on");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("image", "dbo");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.TwoFactorAuthentication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("created_on");

                    b.Property<string>("TwoFactorCode")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)")
                        .HasColumnName("two_factor_code");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_on");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("two_factor_authentication", "dbo");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("CoverImage")
                        .IsRequired()
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("cover_image");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("created_on");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("email");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("bit")
                        .HasColumnName("is_banned");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit")
                        .HasColumnName("is_email_confirmed");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotNullProperty")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Album")
                        .HasColumnName("not_null_property");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("varchar(120)")
                        .HasColumnName("profile_image");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_on");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user", "dbo");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.Album", b =>
                {
                    b.HasOne("FacebookClone.DAL.Entities.User", "User")
                        .WithMany("Albums")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_album_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.Comment", b =>
                {
                    b.HasOne("FacebookClone.DAL.Entities.Album", "Album")
                        .WithMany("Comments")
                        .HasForeignKey("AlbumId")
                        .IsRequired()
                        .HasConstraintName("FK_comment_album");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.EmailConfirm", b =>
                {
                    b.HasOne("FacebookClone.DAL.Entities.User", "User")
                        .WithMany("EmailConfirms")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_email_confirm_user");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.Image", b =>
                {
                    b.HasOne("FacebookClone.DAL.Entities.Album", "Album")
                        .WithMany("Images")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_image_album");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.Album", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("FacebookClone.DAL.Entities.User", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("EmailConfirms");
                });
#pragma warning restore 612, 618
        }
    }
}
