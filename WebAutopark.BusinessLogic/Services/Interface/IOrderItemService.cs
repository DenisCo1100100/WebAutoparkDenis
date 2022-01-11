using System.Collections.Generic;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Base;

namespace WebAutopark.BusinessLogic.Services.Interface
{
    public interface IOrderItemService : IDataService<OrderItemDto>
    {
        IEnumerable<OrderItemDto> GetAllItems(int orderId);
    }
}
