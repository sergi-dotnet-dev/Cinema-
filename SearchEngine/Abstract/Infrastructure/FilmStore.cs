using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SearchEngine.Abstract.Interfaces;
using SearchEngine.Code.Models;
using SearchEngine.DAL;

namespace SearchEngine.Abstract.Infrastructure;

public class FilmStore : IFilmStore
{
    private readonly SearchEngineBoundedContext _context;

    public FilmStore(SearchEngineBoundedContext context) => _context = context;

    public IEnumerable<Film> Get(String subStr)
    {
        return _context.Films
            .Select(f => new Film() { Name = f.Name, Id = f.Id, Year = f.Year, Image = f.Image, Rating = f.Rating })
            .Include(f => f.Categories.Where(c => c.FilmId == f.Id))
            .ThenInclude(c => c.Category.Name)
            .Where(f => f.Name.Contains(subStr))
            .OrderByDescending(f => f.Rating)
            .Take(5);
    }

    public IEnumerable<Film> Get(Int32[] categories)
    {
        return _context.Films
            .Select(f => new Film() { Name = f.Name, Id = f.Id, Year = f.Year, Image = f.Image, Rating = f.Rating })
            .Include(f => f.Categories.Where(c => categories.All(i => i == c.CategoryId)))
            .ThenInclude(c=>c.Category.Name)
            .OrderByDescending(f => f.Rating)
            .Take(5);
    }
    public IIncludableQueryable<Film, Actor> Get(Int32 filmId)
    {
        return _context.Films
               .Select(f => new Film() { Id = f.Id, Name = f.Name, Year = f.Year, Image = f.Image, Rating = f.Rating, Description = f.Description })
               .Where(f => f.Id == filmId)
               .Include(f => f.Categories.Where(c => c.FilmId == f.Id))
               .ThenInclude(c => c.Category.Name)
               .Include(f => f.Actors.Where(a => a.FilmId == f.Id))
               .ThenInclude(a => a.Actor);
    }
}
