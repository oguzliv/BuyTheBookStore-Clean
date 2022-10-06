using System.ComponentModel.DataAnnotations;

namespace BuyTheBookStore.Application.Dtos.OrderAPIDtos
{
    public class OrderDto
    {
        [Required]
        public OrderItem[] OrderItems { get; set; } 
    }
}
