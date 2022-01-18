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
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _orderItemRepository = repository;
        }

        public IEnumerable<OrderItemDto> GetAllItems(int orderId)
        {
            var orderItems = _orderItemRepository.GetAllItems(orderId);
            var orderItemsDto = _mapper.Map<IEnumerable<OrderItemDto>>(orderItems);

            return orderItemsDto;
        }
    }
}
