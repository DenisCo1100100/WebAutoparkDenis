using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.Models;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IDataService<VehicleTypeDto> _vehicleTypeService;
        private readonly IMapper _mapper;

        public VehicleTypeController(IDataService<VehicleTypeDto> vehicleTypeServicec, IMapper mapper)
        {
            _vehicleTypeService = vehicleTypeServicec;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var vehicleTypeList = _vehicleTypeService.GetAllItems();

            var vehicleTypeViewModel = _mapper.Map<IEnumerable<VehicleTypeViewModel>>(vehicleTypeList);
            return View(vehicleTypeViewModel);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var vehicleTypeDto = _vehicleTypeService.GetItem(id);

            if (vehicleTypeDto is null)
                return NotFound();

            var vehicleTypeViewModel = _mapper.Map<VehicleTypeViewModel>(vehicleTypeDto);
            return View(vehicleTypeViewModel);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleTypeDto = _mapper.Map<VehicleTypeDto>(vehicleTypeViewModel);
                _vehicleTypeService.Create(vehicleTypeDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var vehicleTypeDto = _vehicleTypeService.GetItem(id);

            if (vehicleTypeDto is null)
                return NotFound();

            var vehicleTypeViewModel = _mapper.Map<VehicleTypeViewModel>(vehicleTypeDto);
            return View(vehicleTypeViewModel);
        }

        [HttpPost]
        public IActionResult Update(VehicleTypeViewModel vehicleTypeViewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleTypeDto = _mapper.Map<VehicleTypeDto>(vehicleTypeViewModel);
                _vehicleTypeService.Update(vehicleTypeDto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var vehicleTypeDto = _vehicleTypeService.GetItem(id);

            if (vehicleTypeDto is null)
                return NotFound();

            var vehicleTypeViewModel = _mapper.Map<VehicleTypeViewModel>(vehicleTypeDto);
            return View(vehicleTypeViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _vehicleTypeService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
