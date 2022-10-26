using Microsoft.EntityFrameworkCore;
using SearchEngine.Code.Models;

namespace SearchEngine.DAL;

public class SearchEngineBoundedContext : DbContext
{
    private readonly String _connectionString;
    public SearchEngineBoundedContext(String connString) => _connectionString = connString;

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
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
