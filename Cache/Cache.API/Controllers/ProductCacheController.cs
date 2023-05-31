using Cache.Domain.Enums;
using Cache.Domain.Interfaces;
using Cache.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Cache.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductCacheController : ControllerBase
    {
        private readonly ICacheRepository _cacheRepository;
        private readonly IProductRepository _productRepository;

        public ProductCacheController(ICacheRepository cacheRepository,
                               IProductRepository productRepository)
        {
            _cacheRepository = cacheRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            var productCache = await _cacheRepository.GetByKeyAsync(CacheKeys.Products);

            IEnumerable<Product> product;
            if (!string.IsNullOrWhiteSpace(productCache))
            {
                product = JsonConvert.DeserializeObject<IEnumerable<Product>>(productCache)!;

                return Ok(product);
            }

            product = await _productRepository.GetAllProducts();

            await _cacheRepository.SetAsync(CacheKeys.Products, JsonConvert.SerializeObject(product));

            return Ok(product);
        }
    }
}
