namespace EventLibrary;
public interface IEventSender
{
    public void Raise(String eventName, Int32 userId, Object content);
    //public IEnumerable<Event> GetEvents(Int64 firstEventSeqNumber, Int64 lastEventSeqNumber);
}
public class EventSender : IEventSender
{
    public void Raise(String eventName, Int32 userId, Object content)
    {
     
    }
}