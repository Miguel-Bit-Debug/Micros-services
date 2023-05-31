using Cache.Domain.Interfaces;
using Cache.Domain.Models;
using Cache.InfraData.Data;
using MongoDB.Driver;

namespace Cache.InfraData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _colletion;

        public ProductRepository(IMongoDbContext dbContext)
        {
            _colletion = dbContext.Collection<Product>();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _colletion.Find(obj => true).ToListAsync();
            return products;
        }
    }
}
