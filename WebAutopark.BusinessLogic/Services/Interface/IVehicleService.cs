using System.Collections.Generic;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.Core.Enums;

namespace WebAutopark.BusinessLogic.Services.Interface
{
    public interface IVehicleService : IDataService<VehicleDto>
    {
        public IEnumerable<VehicleDto> GetAllItems(SortCriteria sortCriteria, bool isAscending);
    }
}
