using AutoMapper;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.Core.Entities;

namespace WebAutopark.BusinessLogic.MapperProfiles
{
    public class DtoEntityProfile : Profile
    {
        public DtoEntityProfile() 
        {
            CreateMap<ComponentDto, Component>().ReverseMap();
            CreateMap<VehicleTypeDto, VehicleType>().ReverseMap();
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();
        }
    }
}
