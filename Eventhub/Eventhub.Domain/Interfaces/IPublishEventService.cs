namespace Eventhub.Domain.Interfaces
{
    public interface IPublishEventService<T> where T : class
    {
        Task Publish(string user, T message);
    }
}
