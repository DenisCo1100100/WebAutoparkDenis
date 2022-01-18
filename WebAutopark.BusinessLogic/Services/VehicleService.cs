using AutoMapper;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Base.Services;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Interface;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Enums;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehicleService : BaseService<VehicleDto, Vehicle>, IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _vehicleRepository = repository;
        }

        public IEnumerable<VehicleDto> GetAllItems(SortCriteria sortCriteria, bool isAscending)
        {
            var vehicles = _vehicleRepository.GetAllItems(sortCriteria, isAscending);
            var vehiclesDto = _mapper.Map<IEnumerable<VehicleDto>>(vehicles);

            return vehiclesDto;
        }
    }
}