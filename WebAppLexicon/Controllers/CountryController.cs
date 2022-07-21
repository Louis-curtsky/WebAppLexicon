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
    public class CountryController : Controller
    {
        private readonly ICountryServices _countryService;

        public CountryController(ICountryServices countryService)
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View(_countryService.GetAll());
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
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                Country country = _countryService.Create(createCountry);
                if (country != null)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("System", "Fail to create country!!!");
            }
            return View(createCountry);
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            Country country = _countryService.FindById(id);

            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateCountryViewModel editCountry = new CreateCountryViewModel()
            {
                CountryName = country.CntyName
            };


            ViewBag.id = id;

            return View(editCountry);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateCountryViewModel country)
        {
            if (ModelState.IsValid)
            {
                if (_countryService.Edit(id, country) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to edit Country!!!");
            }
            ViewBag.id = id;
            return View(country);
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            Country country = _countryService.FindById(id);

            if (country != null)
            {
                if (_countryService.Remove(id))
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("System", "Fail to delete country!!!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetCountries()
        {
            return Json(_countryService.GetAll());
        }
    }
}
