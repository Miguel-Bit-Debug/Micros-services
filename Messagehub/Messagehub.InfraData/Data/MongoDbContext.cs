using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Messagehub.InfraData.Data;

public class MongoDbContext : IMongoDbContext
{
    public IClientSessionHandle Session { get; set; }
    private readonly IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        var mongoClient = new MongoClient(configuration["MongoConnection"]);
        _database = mongoClient.GetDatabase("ICut");
    }

    public IMongoCollection<T> Collection<T>()
    {
        return _database.GetCollection<T>(typeof(T).Name);
    }

    public void Dispose()
    {
        Session?.Dispose();
        GC.SuppressFinalize(this);
    }
}
