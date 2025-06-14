using AutoMapper;
using Moq;
using ProductService.API.Mapping;
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
    }
}
