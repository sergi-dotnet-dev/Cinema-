using SearchEngine.Abstract.Interfaces;
using SearchEngine.Code.Models;
using SearchEngine.DAL;

namespace SearchEngine.Abstract.Infrastructure;

public class EventHandler : IEventHandler
{
    private readonly SearchEngineBoundedContext _context;

    public EventHandler(SearchEngineBoundedContext context) => _context = context;

    //public IEnumerable<Event> GetEvents(Int64 firstEventSeqNumber, Int64 lastEventSeqNumber)
    //{
    //    using (_context)
    //    {
    //        //return _context.Events.Where(e => e.Id >= firstEventSeqNumber && e.Id <= lastEventSeqNumber).OrderBy(e=>e.Id);
    //    }
    //}

    public async void Raise(String eventName, Int32 userId, Object content)
    {
        if (content == null)
            return;
        var eventContent = (String)content + $"{userId}";

        using (_context)
        {
            _context.Events.Add(new Event() { EventName = eventName, RaiseTime = DateTime.Now, Content = eventContent });
            await _context.SaveChangesAsync();
        }
    }
}
