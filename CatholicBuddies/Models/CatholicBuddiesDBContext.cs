using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatholicBuddies.Models
{
    public partial class CatholicBuddiesDBContext : DbContext
    {
        public CatholicBuddiesDBContext()
        {
        }

        public CatholicBuddiesDBContext(DbContextOptions<CatholicBuddiesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BuddyTable> BuddyTable { get; set; }
        public virtual DbSet<DirectMessage> DirectMessage { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=CatholicBuddiesDB;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuddyTable>(entity =>
            {
                entity.HasKey(e => e.FriendId);

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.BuddyId).HasColumnName("BuddyID");

                entity.Property(e => e.MyId).HasColumnName("MyID");

                entity.HasOne(d => d.Buddy)
                    .WithMany(p => p.BuddyTableBuddy)
                    .HasForeignKey(d => d.BuddyId)
                    .HasConstraintName("FK_BuddyTable_BuddyTable_FriendID");

                entity.HasOne(d => d.My)
                    .WithMany(p => p.BuddyTableMy)
                    .HasForeignKey(d => d.MyId)
                    .HasConstraintName("FK_BuddyTable_UserInfo_myID");
            });

            modelBuilder.Entity<DirectMessage>(entity =>
            {
                entity.HasKey(e => e.MessageId);

                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.MessageText)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverId).HasColumnName("ReceiverID");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.DirectMessageReceiver)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DirectMessage_ReceiverInfo");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.DirectMessageSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DirectMessage_SenderInfo");
            });

            modelBuilder.Entity<Photos>(entity =>
            {
                entity.HasKey(e => e.PhotoId);

                entity.Property(e => e.PhotoId).HasColumnName("PhotoID");

                entity.Property(e => e.UploadTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserPhoto).HasColumnType("image");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Photos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photos_UserInfo");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.Message)
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.PostImage).HasColumnType("image");

                entity.Property(e => e.PostIndex).HasColumnType("datetime");

                entity.Property(e => e.RecipientId).HasColumnName("RecipientID");

                entity.Property(e => e.SenderId).HasColumnName("SenderID");

                entity.HasOne(d => d.Recipient)
                    .WithMany(p => p.PostsRecipient)
                    .HasForeignKey(d => d.RecipientId)
                    .HasConstraintName("FK_Posts_ReceiverInfo");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.PostsSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_SenderIDlink");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.InverseUser)
                    .HasForeignKey<UserInfo>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInfo_UserInfo");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Diocese)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePic).HasColumnType("image");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserProfile)
                    .HasForeignKey<UserProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_UserInfo1");

                entity.HasOne(d => d.UserNavigation)
                    .WithOne(p => p.InverseUserNavigation)
                    .HasForeignKey<UserProfile>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserProfile_UserProfile");
            });
        }
    }
}
