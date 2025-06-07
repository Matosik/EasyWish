using Microsoft.EntityFrameworkCore;
using EasyWish.Domain.Class;

namespace EasyWish.Domain;

public class EasyWishContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<Wish> Wishes { get; set; }
    public DbSet<Friendship> Friendships { get; set; }
    public EasyWishContext()
    {
        Database.EnsureCreated();
    }
    public EasyWishContext(DbContextOptions<EasyWishContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Test;Username=postgres;Password=123");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Friendship>()
            .HasOne(f => f.Initiator)
            .WithMany(u => u.SentFriendships)
            .HasForeignKey(f => f.InitiatorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Friendship>()
            .HasOne(f => f.Recipient)
            .WithMany(u => u.ReceivedFriendships)
            .HasForeignKey(f => f.RecipientId)
            .OnDelete(DeleteBehavior.Cascade);

        // Ограничение уникальности на нормализованную пару
        modelBuilder.Entity<Friendship>()
            .HasIndex(f => new { f.UserAId, f.UserBId })
            .IsUnique();

        //===========
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Nickname)
            .IsUnique();

        modelBuilder.Entity<Wish>()
            .HasOne<WishList>()
            .WithMany(wl => wl.Wishes)
            .HasForeignKey(w => w.WishListId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<WishList>()
            .HasOne<User>()
            .WithMany(u => u.Lists)
            .HasForeignKey(wl => wl.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        base.OnModelCreating(modelBuilder);
    }
}
