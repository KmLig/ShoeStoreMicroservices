namespace ProductService.Application.DTOs
{
    public class CreateShoeDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int Size { get; set; }
        public string Color { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

