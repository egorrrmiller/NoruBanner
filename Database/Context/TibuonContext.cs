using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public class TibuonContext : DbContext
{
    public TibuonContext(DbContextOptions<TibuonContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Bunner> Bunners { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Base = tibuon.db");
        base.OnConfiguring(optionsBuilder);
    }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bunner>().HasData(Enumerable.Range(1, 50).Select(i => new Bunner
        {
            BunnerId = Guid.NewGuid()
        }));

        base.OnModelCreating(modelBuilder);
    }
}