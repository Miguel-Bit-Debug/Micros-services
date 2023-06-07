using MongoDB.Driver;
using Product.Domain.Interfaces;
using Product.InfraData.Data;

namespace Product.InfraData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Domain.Models.Product> _collection;

        public ProductRepository(IMongoDbContext context)
        {
            _collection = context.Collection<Domain.Models.Product>();
        }

        public async Task AddPRoduct(Domain.Models.Product product)
        {
            await _collection.InsertOneAsync(product);
        }
    }
}
