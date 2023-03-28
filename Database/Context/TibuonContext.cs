using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public class TibuonContext : DbContext
{
    public TibuonContext(DbContextOptions<TibuonContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Banner> Banners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Banner>().HasData(Enumerable.Range(1, 10).Select(i => new Banner
        {
            BannerId = Guid.NewGuid()
        }));

        base.OnModelCreating(modelBuilder);
    }
}