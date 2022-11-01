using Microsoft.EntityFrameworkCore;
using SearchEngine.Code.Models;

namespace SearchEngine.DAL;

public sealed class SearchEngineBoundedContext : DbContext
{
    private readonly String _connectionString;
    public SearchEngineBoundedContext(String connString)
        => _connectionString = connString;

    public DbSet<Film> Films { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Event> Events { get; set; }

    public DbSet<FilmCategory> FilmCategories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<FilmCategory>()
            .HasKey(i => new { i.FilmId, i.CategoryId });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
