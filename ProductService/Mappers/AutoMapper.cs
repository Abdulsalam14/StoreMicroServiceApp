using AutoMapper;
using ProductService.Dtos;
using ProductService.Entities;

namespace ProductService.Mappers
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
