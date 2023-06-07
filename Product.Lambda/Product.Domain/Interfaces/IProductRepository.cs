namespace Product.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task AddPRoduct(Models.Product product);
    }
}
