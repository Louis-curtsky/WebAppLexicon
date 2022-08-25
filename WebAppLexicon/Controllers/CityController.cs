using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models;
using WebAppLexicon.Models.Members.Services;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityServices _cityService;
        private readonly IStateServices _stateService;

        public CityController(ICityServices cityServices, IStateServices stateServices)
        {
            _cityService = cityServices;
            _stateService = stateServices;
        }
        // GET: Cities
        public ActionResult Index()
        {
            return View(_cityService.GetAll());
        }

        // GET: Cities/Details/5
        public IActionResult Details(int id)
        {
            City city = _cityService.FindById(id);
            return Json(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            CreateCityViewModel model = new CreateCityViewModel();
            ViewBag.StateList = _stateService.GetAll();
            return View(model);
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createCity)
        {
            if (ModelState.IsValid && createCity.StateId > 0)
            {
                City cityView = _cityService.Create(createCity);
                if (cityView != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to Create City!!!");
            }
//            createCity.StateList = _stateService.GetAll();
            return View(createCity);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int id)
        {
            City city = _cityService.FindById(id);

            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.id = id;
            ViewBag.StateList = _stateService.GetAll();
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, City city)
        {
            if (ModelState.IsValid)
            {
                if (_cityService.Edit(city) == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to edit City!!!");
            }
            ViewBag.id = id;
            ViewBag.StateList = _stateService.GetAll();
            return View(city);
        }

        // GET: Cities/Delete/5
        public IActionResult Delete(int id)
        {

            if (_cityService.FindById(id) != null)
            {
                City city = _cityService.GetCity(id);
                if (_cityService.Remove(city))
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("System", "Fail to create country!!!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetCities()
        {
            return Json(_cityService.GetAll());
        }
    }
}
