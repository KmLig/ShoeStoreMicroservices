using OrderService.Application.DTOs;

namespace OrderService.Application.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto> CreateAsync(CreateOrderDto orderDto);
        Task UpdateAsync(Guid id, CreateOrderDto orderDto);
        Task DeleteAsync(Guid id);
    }
}
