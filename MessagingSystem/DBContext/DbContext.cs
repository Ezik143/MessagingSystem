using MessagingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessagingSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Chat> Chats => Set<Chat>();
        public DbSet<ChatParticipant> ChatParticipants => Set<ChatParticipant>();
        public DbSet<Message> Messages => Set<Message>();
        public DbSet<Attachment> Attachments => Set<Attachment>();
        public DbSet<ReadReceipt> ReadReceipts => Set<ReadReceipt>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //composite entity
            modelBuilder.Entity<ChatParticipant>()
                .HasKey(cp => new { cp.ChatId, cp.UserId });

            modelBuilder.Entity<ReadReceipt>().HasKey(r => new { r.MessageId, r.UserId });

            //Entity Framework Core Relationships / Relationship Configuration
            modelBuilder.Entity<Chat>()
            .HasOne(c => c.Messages)
            .WithMany()
            .HasForeignKey(c => c.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(s => s.SenderId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ChatParticipant>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(cp => cp.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ReadReceipt>()
            .HasOne(m => m.Message)
            .WithMany()
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

