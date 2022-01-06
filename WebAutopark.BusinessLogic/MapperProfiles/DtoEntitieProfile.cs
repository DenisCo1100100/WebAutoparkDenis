using AutoMapper;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.Core.Entities;

namespace WebAutopark.BusinessLogic.MapperProfiles
{
    public class DtoEntitieProfile : Profile
    {
        public DtoEntitieProfile() 
        {
            CreateMap<ComponentDto, Component>().ReverseMap();
            CreateMap<VehicleTypeDto, VehicleType>().ReverseMap();
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
        }
    }
}
