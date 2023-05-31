namespace Cache.Domain.Interfaces
{
    public interface ICacheRepository
    {
        Task SetAsync(string key, string value);
        Task<string> GetByKeyAsync(string key);
    }
}
