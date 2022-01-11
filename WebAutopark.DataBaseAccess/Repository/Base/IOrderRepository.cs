using WebAutopark.Core.Entities;

namespace WebAutopark.DataBaseAccess.Repository.Base
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order Create(int vehicleId);
    }
}
