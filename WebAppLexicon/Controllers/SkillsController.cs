using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models;
using WebAppLexicon.Models.Members;
using WebAppLexicon.Models.Members.Services;

namespace WebAppLexicon.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillServices _skillService;
        private readonly ISkillCatsServices _skillCatsServices;

        public SkillsController(ISkillServices skillService, ISkillCatsServices skillCatsServices)
        {
            _skillService = skillService;
            _skillCatsServices = skillCatsServices;
        }
        
        // GET: SkillsController
        public ActionResult Index()
        {
            List<Skills> skillList = _skillService.GetAll();

            return View(skillList);
        }

        // GET: SkillsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SkillsController/Create
        public ActionResult Create(int memberId, int skillId)
        {
            List<Skills> skillList = _skillService.GetMySkill(memberId, skillId);
            if (skillList == null)
                ViewBag.skillList = "";
            else
                ViewBag.skillList = skillList;
            return View();
        }

        // POST: SkillsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SkillsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SkillsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SkillsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SkillsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
