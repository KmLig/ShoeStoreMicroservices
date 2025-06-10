using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface IShoeRepository
    {
        Task<IEnumerable<Shoe>> GetAllAsync();
        Task<Shoe?> GetByIdAsync(Guid id);
        Task<Shoe> AddAsync(Shoe shoe);
        Task UpdateAsync(Shoe shoe);
        Task DeleteAsync(Guid id);
    }
}
