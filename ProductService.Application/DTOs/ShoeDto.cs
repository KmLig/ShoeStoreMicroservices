namespace ProductService.Domain.DTOs
{
    public class ShoeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Quantity { get; set; } = string.Empty;
        public int Size { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
