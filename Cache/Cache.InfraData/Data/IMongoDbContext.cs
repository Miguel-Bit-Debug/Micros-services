using MongoDB.Driver;

namespace Cache.InfraData.Data
{
    public interface IMongoDbContext : IDisposable
    {
        IMongoCollection<T> Collection<T>();
        IMongoCollection<T> Collection<T>(string collectionName);
    }
}
