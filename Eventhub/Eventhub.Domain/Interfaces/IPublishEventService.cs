using Eventhub.Domain.Models;

namespace Eventhub.Domain.Interfaces
{
    public interface IPublishEventService
    {
        Task Publish(string user, Message message);
    }
}
