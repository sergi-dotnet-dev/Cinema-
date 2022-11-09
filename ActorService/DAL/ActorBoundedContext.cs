using Microsoft.EntityFrameworkCore;
using ActorService.Code.Models;
using ReviewService.Code.Models;

namespace ActorService.DAL;

public sealed class ActorBoundedContext : DbContext
{
    public ActorBoundedContext(DbContextOptions<ActorBoundedContext> options) : base(options)
    { }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<FilmActor> FilmActors { get; set; }
    public DbSet<ActorEvent> ActorEvents { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<FilmActor>()
            .HasKey(k => new { k.ActorId, k.FilmId });
    }
}
