using Microsoft.Extensions.Logging;
using RegistrationService.Abstract.Interfaces;
using RegistrationService.Code.Models;
using RegistrationService.DAL;

namespace RegistrationService.Abstract.Infrastructure;

public class EventSender : IEventSender
{
    private readonly RegistrationBoundedContext _context;

    public EventSender(RegistrationBoundedContext context) => _context = context;

    public async void Raise(String eventName, Int32 userId, Object content)
    {
        if (content == null)
            return;
        var eventContent = (String)content + $"{userId}";

        using (_context)
        {
            _context.UserEvents.Add(new UserEvent() { EventName = eventName, RaiseTime = DateTime.Now, Content = eventContent });
            await _context.SaveChangesAsync();
        }
    }
}
