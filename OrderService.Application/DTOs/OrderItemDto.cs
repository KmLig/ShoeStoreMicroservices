namespace OrderService.Application.DTOs
{
    internal class OrderItemDto
    {
        public Guid ShoeId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
