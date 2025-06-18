namespace OrderService.Domain.Entities
{
    public class OrderItem
    {
        public Guid ShoeId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
