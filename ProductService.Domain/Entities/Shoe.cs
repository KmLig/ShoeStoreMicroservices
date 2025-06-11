namespace ProductService.Domain.Entities
{
    public class Shoe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }    
        public int Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }
}
