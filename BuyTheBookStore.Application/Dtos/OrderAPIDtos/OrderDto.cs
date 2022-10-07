using System.ComponentModel.DataAnnotations;

namespace BuyTheBookStore.Application.Dtos.OrderAPIDtos
{
    public class OrderDto
    {
        [Required]
        public ICollection<OrderItem> OrderItems { get; set; } 
    }
}
