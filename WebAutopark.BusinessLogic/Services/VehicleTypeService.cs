using AutoMapper;
using WebAutopark.BusinessLogic.Base.Services;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehicleTypeService : BaseService<VehicleTypeDto, VehicleType>
    {
        public VehicleTypeService(IRepository<VehicleType> repository, IMapper mapper)
            : base(repository, mapper)
        {}
    }
}
