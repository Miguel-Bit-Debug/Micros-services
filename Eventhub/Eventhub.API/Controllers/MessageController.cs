using Eventhub.Domain.Interfaces;
using Eventhub.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eventhub.API.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IPublishEventService<Message> _publishEvent;

        public MessageController(IPublishEventService<Message> publishEvent)
        {
            _publishEvent = publishEvent;
        }

        [HttpPost]
        public async Task<IActionResult> SendEvent([FromBody] Message message)
        {
            await _publishEvent.Publish(message.User, message);
            return Ok();
        }
    }
}
