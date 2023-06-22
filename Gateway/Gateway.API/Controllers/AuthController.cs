using Gateway.Domain.DTOs.Request;
using Gateway.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ICut.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _accountService;

        public AuthController(IAuthService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value?.Errors).ToList());
            }

            var tokenLoginAuth = await _accountService.Login(request);

            if (string.IsNullOrEmpty(tokenLoginAuth))
            {
                return BadRequest(new { message = "Email or password it's not correct" });
            }

            return Ok(tokenLoginAuth);

        }

        [HttpPost("create-account")]
        public async Task<IActionResult> CreatAccount([FromBody] AccountRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value?.Errors).ToList());
            }

            var result = await _accountService.CreateAccount(request);

            if (string.IsNullOrEmpty(result))
            {
                return BadRequest(new { message = "Error to create account" });
            }

            return Ok(result);
        }
    }
}
