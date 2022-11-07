using Microsoft.EntityFrameworkCore;
using ReviewService.Code.Models;

namespace ReviewService.DAL;

public sealed class ReviewBoundedContext : DbContext
{
    public ReviewBoundedContext(DbContextOptions<ReviewBoundedContext> options) : base(options)
    { }

    public DbSet<Review> Reviews { get; set; }
    public DbSet<ReviewEvent> ReviewEvents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Review>()
                    .HasKey(k => new { k.UserId, k.FilmId });
    }
}
