using AutoMapper;
using WebAutopark.BusinessLogic.Base.Services;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehicleService : BaseService<VehicleDto, Vehicle>
    {
        public VehicleService(IRepository<Vehicle> repository, IMapper mapper)
            : base(repository, mapper)
        {}
    }
}