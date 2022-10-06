using System.ComponentModel.DataAnnotations;

namespace BuyTheBookStore.Application.Dtos.OrderAPIDtos
{
    public class OrderUpdateDto
    {
        [Required]
        public ICollection<OrderItem> Orders{ get; set; }
    }
}
