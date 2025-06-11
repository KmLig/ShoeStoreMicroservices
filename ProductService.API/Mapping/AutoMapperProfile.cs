using AutoMapper;
using ProductService.Application.DTOs;
using ProductService.Domain.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Shoe, ShoeDto>().ReverseMap();
            CreateMap<CreateShoeDto, Shoe>();
        }
    }
}
