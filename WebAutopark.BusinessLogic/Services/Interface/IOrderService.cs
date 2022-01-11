using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Base;

namespace WebAutopark.BusinessLogic.Services.Interface
{
    public interface IOrderService : IDataService<OrderDto>
    {
        OrderDto Create(int vehicleId);
    }
}
