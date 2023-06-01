namespace Product.Domain.Interfaces
{
    public interface IProductCacheExternalService
    {
        Task<IEnumerable<Models.Product>> GetAllProducts(string token);
    }
}
