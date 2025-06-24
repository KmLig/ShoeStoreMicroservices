namespace OrderService.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalAmount => Items.Sum(item => item.Price * item.Quantity);

    }
}
