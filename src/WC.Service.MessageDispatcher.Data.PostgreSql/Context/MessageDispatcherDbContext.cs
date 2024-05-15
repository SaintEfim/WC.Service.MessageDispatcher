using Microsoft.EntityFrameworkCore;
using WC.Service.MessageDispatcher.Data.Models;

namespace WC.Service.MessageDispatcher.Data.PostgreSql.Context;

public sealed class MessageDispatcherDbContext : DbContext
{
    public MessageDispatcherDbContext(DbContextOptions<MessageDispatcherDbContext> options) : base(options)
    {
        Database.Migrate();
    }
    
    public DbSet<ChatEntity> Chats { get; set; } = null!;
    public DbSet<MessageEntity> Messages { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MessageEntity>()
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages)
            .HasForeignKey(m => m.ChatId);
    }
}