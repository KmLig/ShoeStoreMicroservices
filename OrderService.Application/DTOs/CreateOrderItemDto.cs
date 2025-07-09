using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.DTOs
{
    public class CreateOrderItemDto
    {
        public Guid ShoeId { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }        
    }
}
