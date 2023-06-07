using Amazon.Lambda.SQSEvents;

namespace Product.Domain.Interfaces
{
    public interface IProductService
    {
        Task AddProduct(SQSEvent.SQSMessage message);
    }
}
