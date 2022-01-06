using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IDtoService<VehicleDto> _vehicleDtoService;
        private readonly IMapper _mapper;

        public VehicleController(IDtoService<VehicleDto> vehicleDtoService, IMapper mapper)
        {
            _vehicleDtoService = vehicleDtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vehicleList = _vehicleDtoService.GetAllItems();

            var vehicleViewModel = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicleList);
            return View(vehicleViewModel);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var vehicle = _vehicleDtoService.GetItem(id);

            if (vehicle is null)
                return NotFound();

            var vehicleModel = _mapper.Map<VehicleViewModel>(vehicle);
            return View(vehicleModel);
        }


        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VehicleViewModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                var vehicle = _mapper.Map<VehicleDto>(vehicleModel);
                _vehicleDtoService.Create(vehicle);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var vehicle = _vehicleDtoService.GetItem(id);

            if (vehicle is null)
                return NotFound();

            var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicle);
            return View(vehicleViewModel);
        }

        [HttpPost]
        public IActionResult Update(VehicleViewModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                var vehicle = _mapper.Map<VehicleDto>(vehicleModel);
                _vehicleDtoService.Update(vehicle);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var vehicle = _vehicleDtoService.GetItem(id);

            if (vehicle is null)
                return NotFound();

            var vehicleViewModel = _mapper.Map<VehicleViewModel>(vehicle);
            return View(vehicleViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _vehicleDtoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
