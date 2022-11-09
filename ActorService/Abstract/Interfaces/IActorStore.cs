using ActorService.Code.Models;

namespace ActorService.Abstract.Interfaces;

public interface IActorStore
{
    public IEnumerable<Actor> Get(int filmId);
    public Task Add(Actor actor);
}