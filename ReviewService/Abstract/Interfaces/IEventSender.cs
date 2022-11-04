namespace ReviewService.Abstract.Interfaces;

public interface IEventSender 
{
    public Task Raise(String eventName, Int32 userId, Object content);
}
