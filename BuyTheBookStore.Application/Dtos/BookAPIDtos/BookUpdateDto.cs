using System.ComponentModel.DataAnnotations;

namespace BuyTheBookStore.Application.Dtos.BookAPIDtos
{
    public class BookUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string GenreText { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
