namespace OrderService.Application.DTOs
{
    public class OrderItemDto
    {
        public Guid ShoeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
