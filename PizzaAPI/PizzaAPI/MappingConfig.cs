using AutoMapper;
using PizzaAPI.Models;
using PizzaAPI.Models.Dtos;

namespace Barakas.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mapping = new MapperConfiguration(config =>
            {
                config.CreateMap<Order, OrderDto>().ReverseMap();
                config.CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
                config.CreateMap<Response, ResponseDto>().ReverseMap();
                config.CreateMap<Size, SizeDto>().ReverseMap();
                config.CreateMap<Topping, ToppingDto>().ReverseMap();
            });
            return mapping;
        }
    }
}
