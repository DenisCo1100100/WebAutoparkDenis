using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Services.Interface;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orderList = _orderService.GetAllItems();
            var orderViewModel = _mapper.Map<IEnumerable<OrderViewModel>>(orderList);

            return View(orderViewModel);
        }

        [HttpGet]
        public IActionResult Create(int vehicleId)
        {
            var order = _orderService.Create(vehicleId);

            return RedirectToAction("Create","OrderItem", new { orderId = order.OrderId });
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int orderId)
        {
            var orderDto = _orderService.GetItem(orderId);

            if (orderDto is null)
                return NotFound();

            var orderViewModel = _mapper.Map<OrderViewModel>(orderDto);
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int orderId)
        {
            _orderService.Delete(orderId);
            return RedirectToAction(nameof(Index));
        }
    }
}