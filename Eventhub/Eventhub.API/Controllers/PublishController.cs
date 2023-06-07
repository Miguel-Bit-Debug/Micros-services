using Eventhub.Domain.Interfaces;
using Eventhub.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Eventhub.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PublishController : ControllerBase
    {
        private readonly IPublishEventService _publishEvent;

        public PublishController(IPublishEventService publishEvent)
        {
            _publishEvent = publishEvent;
        }

        [HttpPost]
        public async Task<IActionResult> SendEvent([FromBody] Message message)
        {
            var user = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

            await _publishEvent.Publish(user, message);
            return Ok();
        }
    }
}
