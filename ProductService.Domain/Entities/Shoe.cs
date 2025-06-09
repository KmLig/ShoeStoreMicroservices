using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Entities
{
    public class Shoe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Quantity { get; set; }    
        public int Size { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
    }
}
