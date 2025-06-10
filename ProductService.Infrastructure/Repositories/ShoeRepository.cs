using Microsoft.EntityFrameworkCore;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly AppDbContext _context;
        public ShoeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shoe>> GetAllAsync()
        {
            return await _context.Shoes.ToListAsync().ConfigureAwait(false);
        }

        public async Task<Shoe?> GetByIdAsync(Guid id)
        {
            return await _context.Shoes.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<Shoe> AddAsync(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return shoe;
        }

        public async Task UpdateAsync(Shoe shoe)
        {
            _context.Entry(shoe).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            var shoe = await _context.Shoes.FindAsync(id).ConfigureAwait(false);
            if (shoe != null)
            {
                _context.Shoes.Remove(shoe);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
