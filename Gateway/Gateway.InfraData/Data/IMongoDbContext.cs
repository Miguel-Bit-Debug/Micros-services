using MongoDB.Driver;

namespace Gateway.InfraData.Data
{
    public interface IMongoDbContext : IDisposable
    {
        IMongoCollection<T> Collection<T>();
    }
}
