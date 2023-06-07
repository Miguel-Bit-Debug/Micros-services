namespace Product.Domain.Models
{
    public class Product : Entity
    {
        public Product(string name,
                       string description,
                       decimal price,
                       DateTime createdAt,
                       DateTime updatedAt,
                       int likes)
        {
            Name = name;
            Description = description;
            Price = price;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Likes = likes;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public int Likes { get; private set; }
    }
}
