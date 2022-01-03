using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IRepository<Vehicle> _repository;
        private readonly IMapper _mapper;

        public VehicleController(IRepository<Vehicle> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var componentsList = _repository.GetAllItems();

            return View(_mapper.Map<IEnumerable<VehicleModel>>(componentsList));
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var vehicle = _repository.GetItem(id);

            if (vehicle is null)
                return NotFound();

            var vehicleModel = _mapper.Map<VehicleModel>(vehicle);

            return View(vehicleModel);
        }


        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                var vehicle = _mapper.Map<Vehicle>(vehicleModel);
                _repository.Create(vehicle);

                return RedirectToAction("Index");
            }

            return View(vehicleModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var vehicle = _repository.GetItem(id);

            if (vehicle is null)
            {
                NotFound();
            }

            return View(_mapper.Map<VehicleModel>(vehicle));
        }

        [HttpPost]
        public IActionResult Update(VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                var vehicle = _mapper.Map<Vehicle>(vehicleModel);
                _repository.Update(vehicle);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var vehicle = _repository.GetItem(id);

            if (vehicle is null)
                return NotFound();

            var vehicleView = _mapper.Map<VehicleModel>(vehicle);
            return View(vehicleView);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
