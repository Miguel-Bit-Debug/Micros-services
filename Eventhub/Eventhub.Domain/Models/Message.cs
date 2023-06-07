namespace Eventhub.Domain.Models
{
    public class Message
    {
        public Message(string eventName,
                       object detail)
        {
            EventName = eventName;
            Detail = detail;
        }

        public string EventName { get; private set; }
        public object Detail { get; private set; }
    }
}
