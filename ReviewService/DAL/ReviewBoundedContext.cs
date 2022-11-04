using Microsoft.EntityFrameworkCore;
using ReviewService.Code.Models;

namespace ReviewService.DAL;

public sealed class ReviewBoundedContext : DbContext
{
    private readonly String _connectionString;
    public ReviewBoundedContext() { }
    public ReviewBoundedContext(String connString) 
        => _connectionString = connString;
    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewEvent> ReviewEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Review>()
                    .HasKey(k => new { k.UserId, k.FilmId });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=INSPECTOR\\SQLEXPRESS;Database=ReviewDb;Trusted_Connection=True;MultipleActiveResultSets=True");
    }
}
