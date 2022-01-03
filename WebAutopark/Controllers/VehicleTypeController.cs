using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IRepository<VehicleType> _repository;
        private readonly IMapper _mapper;

        public VehicleTypeController(IRepository<VehicleType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var vehicleList = _repository.GetAllItems();

            return View(_mapper.Map<IEnumerable<VehicleTypeModel>>(vehicleList));
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var vehicleType = _repository.GetItem(id);

            if (vehicleType is null)
                return NotFound();

            var vehicleTypeModel = _mapper.Map<VehicleTypeModel>(vehicleType);

            return View(vehicleTypeModel);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VehicleTypeModel vehicleTypeModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleType = _mapper.Map<VehicleType>(vehicleTypeModel);
                _repository.Create(vehicleType);

                return RedirectToAction("Index");
            }

            return View(vehicleTypeModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var vehicleType = _repository.GetItem(id);

            if (vehicleType is null)
            {
                NotFound();
            }

            return View(_mapper.Map<VehicleTypeModel>(vehicleType));
        }

        [HttpPost]
        public IActionResult Update(VehicleTypeModel vehicleTypeModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleType = _mapper.Map<VehicleType>(vehicleTypeModel);
                _repository.Update(vehicleType);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var vehicleType = _repository.GetItem(id);

            if (vehicleType is null)
                return NotFound();

            var vehicleTypeView = _mapper.Map<VehicleTypeModel>(vehicleType);
            return View(vehicleTypeView);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
