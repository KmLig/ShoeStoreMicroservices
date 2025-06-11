using AutoMapper;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Domain.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Services
{
    public class ShoeService
    {
        private readonly IMapper _mapper;
        private readonly IShoeRepository _shoeRepository;

        public ShoeService(IShoeRepository shoeRepository, IMapper mapper)
        {
            _shoeRepository = shoeRepository;
            _mapper = mapper;
        }

        public async Task<ShoeDto> CreateShoeAsync(CreateShoeDto createShoeDto)
        {
            var newShoe = _mapper.Map<Shoe>(createShoeDto);
            var createdShoe = await _shoeRepository.AddAsync(newShoe).ConfigureAwait(false);

            return _mapper.Map<ShoeDto>(createdShoe);
        }

        public async Task DeleteShoeAsync(Guid id) { await _shoeRepository.DeleteAsync(id).ConfigureAwait(false); }

        public async Task<IEnumerable<ShoeDto>> GetAllShoesAsync()
        {
            var shoes = await _shoeRepository.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<IEnumerable<ShoeDto>>(shoes);
        }

        public async Task<ShoeDto?> GetShoeByIdAsync(Guid id)
        {
            var shoe = await _shoeRepository.GetByIdAsync(id).ConfigureAwait(false);
            if(shoe == null)
                return null;
            return _mapper.Map<ShoeDto>(shoe);
        }

        public async Task UpdateShoeAsync(Guid id, CreateShoeDto shoeDto)
        {
            var shoe = _mapper.Map<Shoe>(shoeDto);
            shoe.Id = id; // Ensure the ID is set for the update
            await _shoeRepository.UpdateAsync(shoe).ConfigureAwait(false);
        }
    }
}
