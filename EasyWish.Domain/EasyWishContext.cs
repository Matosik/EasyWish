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
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>()
            .HasMany<Friendship>()
            .WithOne(u => u.Initiator)
            .HasForeignKey(u => u.InitiatorId);

        //modelBuilder.Entity<WishList>
        //    .HasMany<Wish>()
        //    .WithOne()
        //    .HasForeignKey(w => w.WishListId);
    }
}
