using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using ProductService.API.Mapping;
using ProductService.Application.Interfaces;
using ProductService.Application.Services;

namespace ProductService.Tests.Services
{
    public class ShoeServiceTests
    {
        private readonly ShoeService _shoeService;
        private readonly Mock<IShoeRepository> _repoMock;
        private readonly IMapper _mapperMock;

        public ShoeServiceTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            _mapperMock = config.CreateMapper();
            _repoMock = new Mock<IShoeRepository>();
            _shoeService = new ShoeService(_repoMock.Object, _mapperMock);
        }
    }
}
