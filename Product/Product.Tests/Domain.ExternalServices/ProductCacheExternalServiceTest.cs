using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using Xunit;

namespace Product.Tests.Domain.ExternalServices
{
    public class ProductCacheExternalServiceTest : BaseExternalServiceTest
    {
        [Fact]
        public async Task GetAllProducts()
        {
            var products = new List<Product.Domain.Models.Product>()
            {
                new Product.Domain.Models.Product("teste1",
                                                  "descrição",
                                                  21m,
                                                  DateTime.Now,
                                                  DateTime.Now,
                                                  0),

                new Product.Domain.Models.Product("teste2",
                                                  "descrição",
                                                  22m,
                                                  DateTime.Now,
                                                  DateTime.Now,
                                                  1)
            };

            var request = new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(products)),
                StatusCode = HttpStatusCode.OK,
            };

            _httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(request)
                .Verifiable();

            var response = await _httpClient.GetAsync("http://teste.com");

            var content = await response.Content.ReadAsStringAsync();

            var productsDeserialized = JsonConvert.DeserializeObject<List<Product.Domain.Models.Product>>(content);

            Assert.True(productsDeserialized.Any());
            Assert.IsType<List<Product.Domain.Models.Product>>(productsDeserialized);
            Assert.NotNull(content);
        }
    }
}
