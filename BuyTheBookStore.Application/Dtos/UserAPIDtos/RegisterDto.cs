using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BuyTheBookStore.Application.Dtos.UserAPIDtos
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool? IsAdmin { get; set; }
    }
}
