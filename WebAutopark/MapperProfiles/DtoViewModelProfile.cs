using WebAutopark.Models;
using AutoMapper;
using WebAutopark.BusinessLogic.DataTransferObject;

namespace WebAutopark.MapperProfiles
{
    public class DtoViewModelProfile : Profile
    {

        public DtoViewModelProfile()
        {
            CreateMap<ComponentViewModel, ComponentDto>().ReverseMap();
            CreateMap<VehicleTypeViewModel, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleViewModel, VehicleDto>().ReverseMap();
            CreateMap<OrderViewModel, OrderDto>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemDto>().ReverseMap();
        }
    }
}
