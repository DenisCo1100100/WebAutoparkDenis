using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebAutopark.BusinessLogic.Base.Services;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Interface;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderItemService : BaseService<OrderItemDto, OrderItem>, IOrderItemService
    {
        public OrderItemService(IRepository<OrderItem> repository, IMapper mapper) : base(repository, mapper)
        {}

        public IEnumerable<OrderItemDto> GetAllItems(int orderId) => GetAllItems().Where(e => e.OrderId == orderId);
    }
}
