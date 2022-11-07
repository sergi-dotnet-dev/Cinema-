using Microsoft.EntityFrameworkCore;
using SearchEngine.Code.Models;

namespace SearchEngine.DAL;

public sealed class SearchEngineBoundedContext : DbContext
{
    public SearchEngineBoundedContext(DbContextOptions<SearchEngineBoundedContext> options) : base(options)
    {
        
    }
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
}
