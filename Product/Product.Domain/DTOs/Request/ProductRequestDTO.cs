using System.ComponentModel.DataAnnotations;

namespace Product.Domain.DTOs.Request
{
    public class ProductRequestDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}
