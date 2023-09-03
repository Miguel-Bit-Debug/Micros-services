namespace Product.Domain.DTOs.Request;

public class ProductRequestDTO
{
    public ProductRequestDTO(string name,
                             string description,
                             decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public string Name { get; }
    public string Description { get; }
    public decimal Price { get; }
}
