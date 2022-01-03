using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository.Base;

namespace WebAutopark.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IRepository<Component> _repository;
        private readonly IMapper _mapper;

        public ComponentController(IRepository<Component> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var componentsList = _repository.GetAllItems();

            return View(_mapper.Map<IEnumerable<ComponentModel>>(componentsList));
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var component = _repository.GetItem(id);

            if (component is null)
                return NotFound();

            var componentModel = _mapper.Map<ComponentModel>(component);

            return View(componentModel);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ComponentModel componentModel)
        {
            if (ModelState.IsValid)
            {
                var component = _mapper.Map<Component>(componentModel);
                _repository.Create(component);

                return RedirectToAction("Index");
            }

            return View(componentModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var component = _repository.GetItem(id);

            if (component is null)
            {
                NotFound();
            }

            return View(_mapper.Map<ComponentModel>(component));
        }

        [HttpPost]
        public IActionResult Update(ComponentModel componentModel)
        {
            if (ModelState.IsValid)
            {
                var component = _mapper.Map<Component>(componentModel);
                _repository.Update(component);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var component = _repository.GetItem(id);

            if (component is null)
                return NotFound();

            var componentView = _mapper.Map<ComponentModel>(component);
            return View(componentView);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}