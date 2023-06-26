using MongoDB.Driver;

namespace Messagehub.InfraData.Data;

public interface IMongoDbContext : IDisposable
{
    IMongoCollection<T> Collection<T>();
}
