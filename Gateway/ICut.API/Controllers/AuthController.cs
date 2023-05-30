using ICut.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ICut.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult GenerateToekn()
        {
            var token = _tokenService.GenerateToken();
            return Ok(token);
        }
    }
}
