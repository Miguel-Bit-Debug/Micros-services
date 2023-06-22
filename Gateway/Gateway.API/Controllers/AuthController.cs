using Gateway.Domain.DTOs.Request;
using Gateway.Domain.Interfaces.Services;
using Gateway.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ICut.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAccountService _accountService;

        public AuthController(ITokenService tokenService, IAccountService accountService)
        {
            _tokenService = tokenService;
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<IAccountService> Login([FromBody] LoginRequestDTO request)
        {

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
