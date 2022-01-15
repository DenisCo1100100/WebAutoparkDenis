using System.Collections.Generic;
using WebAutopark.Core.Entities;

namespace WebAutopark.DataBaseAccess.Repository.Base
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        IEnumerable<OrderItem> GetAllItems(int orderId);
    }
}
