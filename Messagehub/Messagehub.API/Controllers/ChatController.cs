using Messagehub.Domain.DTOs;
using Messagehub.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Messagehub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;
        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("register-user")]
        public IActionResult RegisterUser(UserDto model)
        {
            if (_chatService.AddUserToList(model.Name))
            {
                // 204 status code
                return NoContent();
            }

            return BadRequest("This name is taken please choose another name");
        }
    }
}
