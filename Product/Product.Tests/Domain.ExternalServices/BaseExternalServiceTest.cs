using Moq;

namespace Product.Tests.Domain.ExternalServices
{
    public class BaseExternalServiceTest
    {
        protected readonly Mock<HttpMessageHandler> _httpMessageHandler;
        protected readonly HttpClient _httpClient;
        public BaseExternalServiceTest()
        {
            _httpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandler.Object);
        }
    }
}
