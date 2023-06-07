using Amazon.Lambda.SQSEvents;
using Newtonsoft.Json;
using Product.Domain.Interfaces;

namespace Product.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task AddProduct(SQSEvent.SQSMessage message)
        {
            var body = JsonConvert.DeserializeObject<Models.Product>(message.Body);

            var product = new Models.Product(body.Name,
                                             body.Description,
                                             body.Price,
                                             DateTime.UtcNow,
                                             DateTime.UtcNow,
                                             likes: 0);

            await _repository.AddPRoduct(product);
        }
    }
}
