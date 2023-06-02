namespace Eventhub.Domain.Models
{
    public class Message
    {
        public Message(string eventName,
                       string user,
                       object detail)
        {
            EventName = eventName;
            User = user;
            Detail = detail;
        }

        public string EventName { get; private set; }
        public string User { get; private set; }
        public object Detail { get; private set; }
    }
}
