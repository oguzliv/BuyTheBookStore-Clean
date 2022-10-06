namespace BuyTheBookStore.Application.Dtos.UserAPIDtos
{
    public class UserResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
