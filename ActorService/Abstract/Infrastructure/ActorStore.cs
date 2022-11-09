using ActorService.Abstract.Interfaces;
using ActorService.Code.Models;
using ActorService.DAL;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ActorService.Abstract.Infrastructure;

public class ActorStore : IActorStore
{
    private readonly ActorBoundedContext _context;

    public ActorStore(ActorBoundedContext context) => _context = context;

    public async Task Add(Actor actor)
    {
        using (_context)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }
    }

    public IEnumerable<Actor> Get(Int32 filmId)
    {
        using (_context)
        {
            return _context.Actors.FromSqlRaw($"select a.Id,a.Name,a.BornYear, a.Photo " +
                $"from FilmActors as fa " +
                $"inner join Actors as a on a.Id = fa.ActorId " +
                $"where fa.FilmId ={filmId}").ToList();
        }
    }
}
