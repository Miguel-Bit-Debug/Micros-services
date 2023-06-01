using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Domain.DTOs.Request;
using Product.Domain.Interfaces;

namespace Product.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IEventHubExternalService<ProductRequestDTO> _eventHub;

        public ProductController(IEventHubExternalService<ProductRequestDTO> eventHub)
        {
            _eventHub = eventHub;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value.Errors).ToList());
            }

            var user = "teste"; // buscar usuario do token
            var response = await _eventHub.PublishAsync(user, request);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
