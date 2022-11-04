using ReviewService.Code.Models;
using ReviewService.DAL;
using ReviewService.Abstract.Interfaces;

namespace ReviewService.Abstract.Infrastructure;

public class EventSender : IEventSender
{
    private readonly ReviewBoundedContext _context;

    public EventSender(ReviewBoundedContext context) => _context = context;

    public async Task Raise(String eventName, Int32 userId, Object content)
    {
        if (content == null)
            return;
        var eventContent = (String)content + $"{userId}";

        using (_context)
        {
            await _context.ReviewEvents.AddAsync(new ReviewEvent() { EventName = eventName, RaiseTime = DateTime.Now, Content = eventContent });
            await _context.SaveChangesAsync();
        }
    }
}
