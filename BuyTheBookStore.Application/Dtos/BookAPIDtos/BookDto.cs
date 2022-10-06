
namespace BuyTheBookStore.Application.Dtos.BookAPIDtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string GenreText { get; set; }
        public double Price { get; set; }
    }
}
