using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatholicBuddies.Models
{
    public partial class CatholicBuddiesContext : DbContext
    {
        public CatholicBuddiesContext()
        {
        }

        public CatholicBuddiesContext(DbContextOptions<CatholicBuddiesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DirectMessage> DirectMessage { get; set; }
        public virtual DbSet<FriendTable> FriendTable { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=CatholicBuddies;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DirectMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.DirectMessage1)
                    .HasColumnName("DirectMessage")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.RecipientId).HasColumnName("RecipientID");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");
            });

            modelBuilder.Entity<FriendTable>(entity =>
            {
                entity.HasKey(e => e.FriendshipId);

                entity.Property(e => e.FriendshipId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.HasKey(e => e.PhotoId);

                entity.Property(e => e.PhotoId)
                    .HasColumnName("PhotoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.UploadTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserPhoto).HasColumnType("image");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.Postid);

                entity.Property(e => e.Postid).ValueGeneratedNever();

                entity.Property(e => e.Message)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.PostImage).HasColumnType("image");

                entity.Property(e => e.RecipientId).HasColumnName("RecipientID");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.PostsRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .HasConstraintName("FK__Posts__Recipient__5441852A");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.PostsSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__SenderID__5070F446");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasColumnName("FName")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePic).HasColumnType("image");

                entity.Property(e => e.UserCity)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UserDiocese)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.UserState)
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });
        }
    }
}
