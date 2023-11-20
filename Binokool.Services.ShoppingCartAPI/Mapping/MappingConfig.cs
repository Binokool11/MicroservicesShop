using AutoMapper;
using Binokool.Services.ShoppingCartAPI.Models;
using Binokool.Services.ShoppingCartAPI.Models.Dto;

namespace Binokool.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<CartHeader, CartDetailsDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
                config.CreateMap<Cart, CartDto>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
