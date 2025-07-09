namespace OrderService.Application.DTOs
{
    public class OrderItemDto
    {
        public Guid ShoeId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
