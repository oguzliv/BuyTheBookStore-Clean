using System.ComponentModel.DataAnnotations;

namespace BuyTheBookStore.Application.Dtos.OrderAPIDtos
{
    public class OrderItem
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public int Count { get; set; }
    }
}
