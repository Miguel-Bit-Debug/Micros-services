using Microsoft.AspNetCore.Mvc;
using Product.API.Extensions;
using Product.Domain.DTOs.Request;
using Product.Domain.Interfaces;

namespace Product.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IEventHubExternalService<ProductRequestDTO> _eventHubService;
        private readonly IProductCacheExternalService _productCacheService;
        private readonly IHttpContextAccessor _accessor;
        private readonly string Token;

        public ProductController(IEventHubExternalService<ProductRequestDTO> eventHub,
                                 IHttpContextAccessor accessor,
                                 IProductCacheExternalService productCacheService)
        {
            _eventHubService = eventHub;
            _accessor = accessor;
            _productCacheService = productCacheService;
            Token = _accessor.HttpContext?.Request.Headers["Authorization"]!;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Select(x => x.Value?.Errors).ToList());
            }

            var user = HttpContext.User.GetUsernameFromClaim();

            if (user == null)
            {
                return BadRequest("Error user does't exists.");
            }

            var response = await _eventHubService.PublishAsync(user, request, Token);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productCacheService.GetAllProducts(Token);
            return Ok(response);
        }
    }
}
