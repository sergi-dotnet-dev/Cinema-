using SearchEngine.Code.Models;

namespace SearchEngine.Abstract.Interfaces;

public interface IFilmStore
{
    public IEnumerable<Film> Get(String subStr);
    public IEnumerable<Film> Get(Int32[] categories);
}