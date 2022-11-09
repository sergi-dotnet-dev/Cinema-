using ActorService.Code.Models;
using ActorService.DAL;
using ActorService.Abstract.Interfaces;
using ReviewService.Code.Models;

namespace ActorService.Abstract.Infrastructure;

public class EventSender : IEventSender
{
    private readonly ActorBoundedContext _context;

    public EventSender(ActorBoundedContext context) => _context = context;

    public async Task Raise(String eventName, Int32 userId, Object content)
    {
        if (content == null)
            return;
        var eventContent = (String)content + $"{userId}";

        using (_context)
        {
            await _context.ActorEvents.AddAsync(new ActorEvent() { EventName = eventName, RaiseTime = DateTime.Now, Content = eventContent });
            await _context.SaveChangesAsync();
        }
    }
}
