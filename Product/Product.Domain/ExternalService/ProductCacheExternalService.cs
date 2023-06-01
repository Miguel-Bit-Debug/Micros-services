using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Product.Domain.Interfaces;

namespace Product.Domain.ExternalService
{
    public class ProductCacheExternalService : BaseExternalService<Models.Product>, IProductCacheExternalService
    {
        public ProductCacheExternalService(IConfiguration configuration, HttpClient httpClient, ILogger<Models.Product> logger) : base(httpClient, logger)
        {
            BaseUrl = configuration["CacheApiUrl"];

        }

        public async Task<IEnumerable<Models.Product>> GetAllProducts(string token)
        {
            try
            {
                _logger.LogInformation("Buscando todos os produtos");
                _httpClient.DefaultRequestHeaders.Add("Authorization", token);

                var response = await _httpClient.GetAsync($"{BaseUrl}api/ProductCache");

                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<Models.Product>>(content)!;

                return products;

            }
            catch (Exception ex)
            {

                _logger.LogError($"Error get products - {ex.Message}");
                throw ex;
            }
        }
    }
}
