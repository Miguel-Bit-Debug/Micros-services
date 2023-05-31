using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Cache.InfraData.Data
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        public IClientSessionHandle Session { get; set; }

        public MongoDbContext(IConfiguration configuration)
        {
            var mongoClient = new MongoClient(configuration["MongoConnection"]);
            _database = mongoClient.GetDatabase("ICut");
        }

        public IMongoCollection<T> Collection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<T> Collection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }

        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
