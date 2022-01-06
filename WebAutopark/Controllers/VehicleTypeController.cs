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
        private readonly IDtoService<VehicleTypeDto> _vehicleTypeServicec;
        private readonly IMapper _mapper;

        public VehicleTypeController(IDtoService<VehicleTypeDto> vehicleTypeServicec, IMapper mapper)
        {
            _vehicleTypeServicec = vehicleTypeServicec;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var vehicleTypeList = _vehicleTypeServicec.GetAllItems();

            var vehicleTypeViewModel = _mapper.Map<IEnumerable<VehicleTypeViewModel>>(vehicleTypeList);
            return View(vehicleTypeViewModel);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var vehicleType = _vehicleTypeServicec.GetItem(id);

            if (vehicleType is null)
                return NotFound();

            var vehicleTypeModel = _mapper.Map<VehicleTypeViewModel>(vehicleType);
            return View(vehicleTypeModel);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VehicleTypeViewModel vehicleTypeModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleType = _mapper.Map<VehicleTypeDto>(vehicleTypeModel);
                _vehicleTypeServicec.Create(vehicleType);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var vehicleType = _vehicleTypeServicec.GetItem(id);

            if (vehicleType is null)
                return NotFound();

            var vehicleTypeViewModel = _mapper.Map<VehicleTypeViewModel>(vehicleType);
            return View(vehicleTypeViewModel);
        }

        [HttpPost]
        public IActionResult Update(VehicleTypeViewModel vehicleTypeModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleType = _mapper.Map<VehicleTypeDto>(vehicleTypeModel);
                _vehicleTypeServicec.Update(vehicleType);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var vehicleType = _vehicleTypeServicec.GetItem(id);

            if (vehicleType is null)
                return NotFound();

            var vehicleTypeViewModel = _mapper.Map<VehicleTypeViewModel>(vehicleType);
            return View(vehicleTypeViewModel);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _vehicleTypeServicec.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
