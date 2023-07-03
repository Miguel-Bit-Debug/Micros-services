using System.ComponentModel.DataAnnotations;

namespace Messagehub.Domain.DTOs
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; }
    }
}
