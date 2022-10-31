using Microsoft.EntityFrameworkCore.Query;
using SearchEngine.Code.Models;

namespace SearchEngine.Abstract.Interfaces;

public interface IFilmStore
{
    public IEnumerable<Film> Get(String subStr);
    public IEnumerable<Film> Get(Int32[] categories);
    public IIncludableQueryable<Film, Actor> Get(Int32 filmId);
}