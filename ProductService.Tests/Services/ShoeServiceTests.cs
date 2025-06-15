using AutoMapper;
using Moq;
using ProductService.API.Mapping;
using ProductService.Application.DTOs;
using ProductService.Application.Interfaces;
using ProductService.Application.Services;
using ProductService.Domain.Entities;

namespace ProductService.Tests.Services
{
    public class ShoeServiceTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<IShoeRepository> _repoMock;
        private readonly ShoeService _shoeService;

        public ShoeServiceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            _mapperMock = config.CreateMapper();
            _repoMock = new Mock<IShoeRepository>();
            _shoeService = new ShoeService(_repoMock.Object, _mapperMock);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnMappedList()
        {
            // Arrange
            var shoes = new List<Shoe>
                {
                    new() { Id = Guid.NewGuid(), Name = "Air Max", Brand = "Nike", Price = 150, Quantity = 10 },
                    new() { Id = Guid.NewGuid(), Name = "Ultraboost", Brand = "Adidas", Price = 180, Quantity = 5 }
                };
            _repoMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(shoes);
            // Act
            var result = await _shoeService.GetAllShoesAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, s => string.Compare(s.Name, "Air Max", StringComparison.OrdinalIgnoreCase) == 0
            && string.Compare(s.Brand, "Nike", StringComparison.OrdinalIgnoreCase) == 0);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnMappedShoe()
        {
            // Arrange
            var shoe = new Shoe { Id = Guid.NewGuid(), Name = "Air Max", Brand = "Nike", Price = 150, Quantity = 10 };
            _repoMock.Setup(repo => repo.GetByIdAsync(shoe.Id)).ReturnsAsync(shoe);
            // Act
            var result = await _shoeService.GetShoeByIdAsync(shoe.Id);
            // Assert
            Assert.NotNull(result);
            Assert.Equal(shoe.Id, result.Id);
            Assert.Equal(shoe.Name, result!.Name);
        }

        [Fact]
        public async Task CreateShoeAsync_ShouldReturnCreatedShoeDto()
        {
            // Arrange
            var newShoe = new Shoe { Id = Guid.NewGuid(), Name = "Air Max", Brand = "Nike", Price = 150, Quantity = 10 };
            _repoMock.Setup(repo => repo.AddAsync(It.IsAny<Shoe>())).ReturnsAsync(newShoe);
            // Act
            var result = await _shoeService.CreateShoeAsync(new CreateShoeDto
            {
                Name = "Air Max",
                Brand = "Nike",
                Price = 150,
                Quantity = 10
            });
            // Assert
            Assert.NotNull(result);
            Assert.Equal(newShoe.Id, result.Id);
            Assert.Equal(newShoe.Name, result.Name);
        }
    }
}
