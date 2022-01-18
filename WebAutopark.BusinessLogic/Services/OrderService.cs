using AutoMapper;
using WebAutopark.BusinessLogic.Base.Services;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Interface;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.BusinessLogic.Services
{
    public class OrderService : BaseService<OrderDto, Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _orderRepository = repository;
        }

        public OrderDto Create(int vehicleId)
        {
            var order = _orderRepository.Create(vehicleId);
            var orderDto = _mapper.Map<OrderDto>(order);

            return orderDto;
        }
    }
}