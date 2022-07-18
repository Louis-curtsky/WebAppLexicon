using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models;
using WebAppLexicon.Models.Members.Services;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Controllers
{
    public class LanguageController : Controller
    {
        private readonly Models.Members.Services.ILanguageService _languageService;
        private readonly IPeopleService _PeopleService;

        public LanguageController(IPeopleService peopleService, Models.Members.Services.ILanguageService languageService)
        {
            _languageService = languageService;
            _PeopleService = peopleService;
        }
        // GET: LanguageController
        public ActionResult Index()
        {
            return View(_languageService.GetAll());
        }

        // GET: LanguageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LanguageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLanguageViewModel createLanguage)
        {
            if (ModelState.IsValid)
            {
                Language language = _languageService.Create(createLanguage);
                if (language != null)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("System", "Fail to create language!!!");
            }
            return View(createLanguage);
        }

        // GET: LanguageController/Edit/5
        public ActionResult Edit(int id)
        {
            Language lang = _languageService.FindById(id);

            if (lang == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateLanguageViewModel editLanguage = new CreateLanguageViewModel()
            {
                LangName = lang.LangName
            };

            ViewBag.id = id;

            return View(editLanguage);
        }

        // POST: LanguageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateLanguageViewModel language)
        {
            if (ModelState.IsValid)
            {
                if (_languageService.Edit(id, language) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to edit Language!!!");
            }
            ViewBag.id = id;
            return View(language);
        }


        // GET: LanguageController/Delete/5
        public ActionResult Delete(int id)
        {
            Language lang = _languageService.FindById(id);

            if (lang != null)
            {
                if (_languageService.Remove(id))
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("System", "Fail to delete Language!!!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetLanguages()
        {
            return Json(_languageService.GetAll());
        }
    }
}
