using AutoMapper;
using Binokool.Services.ProductAPI.Models;
using Binokool.Services.ProductAPI.Models.Dtos;

namespace Binokool.Services.ProductAPI
{
    //Необходим для преобразования объекта ProductDto в Product и наоборот
    public class MappingConfig
    {
        /// <summary>
        /// Преобразование объекта ProductDto в Product и наоборот
        /// </summary>
        /// <returns>MapperConfiguration</returns>
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });
            return mappingConfig;
        }
    }
}
