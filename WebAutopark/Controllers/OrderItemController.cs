using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.Services.Interface;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IDataService<ComponentDto> _componentDataService;
        private readonly IMapper _mapper;

        public OrderItemController(IOrderItemService orderItemService, IDataService<ComponentDto> componentDataService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _componentDataService = componentDataService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(int orderId)
        {
            var orderItems = _orderItemService.GetAllItems(orderId);
            var orderItemViewModel = _mapper.Map<IEnumerable<OrderItemViewModel>>(orderItems);

            return View(orderItemViewModel);
        }

        [HttpGet]
        public IActionResult Create(int orderId)
        {
            var orderItemViewModel = new OrderItemViewModel { OrderId = orderId };
            var componentsDto = _componentDataService.GetAllItems();
            var componentsViewModel = _mapper.Map<IEnumerable<ComponentViewModel>>(componentsDto);

            ViewBag.Components = componentsViewModel;
            return View(orderItemViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderItemViewModel orderItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var orderItemDto = _mapper.Map<OrderItemDto>(orderItemViewModel);
                _orderItemService.Create(orderItemDto);
            }

            return RedirectToAction("Index", "Order", new { orderId = orderItemViewModel.OrderId });
        }
    }
}