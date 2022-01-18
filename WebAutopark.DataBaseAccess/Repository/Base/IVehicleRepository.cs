using System.Collections.Generic;
using WebAutopark.Core.Entities;
using WebAutopark.Core.Enums;

namespace WebAutopark.DataBaseAccess.Repository.Base
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        IEnumerable<Vehicle> GetAllItems(SortCriteria sortCriteria, bool isAscending);
    }
}
