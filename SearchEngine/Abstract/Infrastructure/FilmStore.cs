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
            .Where(f => f.Name.Contains(subStr))
            .OrderByDescending(f => f.Rating);
    }

    public IEnumerable<Film> Get(Int32[] categories)
    {
        throw new NotImplementedException();
    }
}
