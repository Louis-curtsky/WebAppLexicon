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
    public class StateController : Controller
    {
        private readonly IStateServices _stateService;
        private readonly ICountryServices _countryService;

        public StateController(IStateServices stateServices, ICountryServices countryServices)
        {
            _stateService = stateServices;
            _countryService = countryServices;
        }
        public ActionResult Index()
        {
            return View(_stateService.GetAll());
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            // More coding..pending
            return View();
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            CreateStateViewModel model = new CreateStateViewModel();
            ViewBag.CountryList = _countryService.GetAll();
            return View(model);
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateStateViewModel createState)
        {
            if (ModelState.IsValid)
            {
                State state = _stateService.Create(createState);
                if (state != null)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("System", "Fail to create country!!!");
            }
            return View(createState);
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            State state = _stateService.FindById(id);

            if (state == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateStateViewModel editState = new CreateStateViewModel()
            {
                StateName = state.StateName
            };


            ViewBag.id = id;

            return View(editState);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateStateViewModel state)
        {
            if (ModelState.IsValid)
            {
                if (_stateService.Update(id, state) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to edit Country!!!");
            }
            ViewBag.id = id;
            return View(state);
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            State state = _stateService.FindById(id);

            if (state != null)
            {
                if (_stateService.Remove(id))
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("System", "Fail to delete country!!!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetStates()
        {
            return Json(_stateService.GetAll());
        }
    }
}
