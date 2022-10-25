using Microsoft.EntityFrameworkCore;
using SearchEngine.Code.Models;

namespace SearchEngine.DAL;

public class SearchEngineBoundedContext : DbContext
{
    public SearchEngineBoundedContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Film> Films { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public DbSet<FilmCategory> FilmCategories { get; set; }
    public DbSet<FilmActor> FilmActors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FilmCategory>()
            .HasKey(i => new { i.FilmId, i.CategoryId });
        modelBuilder.Entity<FilmActor>()
            .HasKey(i => new { i.FilmId, i.ActorId });
    }
}
