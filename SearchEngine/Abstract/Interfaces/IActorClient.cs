using SearchEngine.Code.Models;

namespace SearchEngine.Abstract.Interfaces;

public interface IActorClient
{
    public Task<IEnumerable<Actor>> GetFilmActor(Int32 filmId);
}