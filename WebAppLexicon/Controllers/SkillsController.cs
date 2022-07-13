using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models;
using WebAppLexicon.Models.Members;
using WebAppLexicon.Models.Members.Services;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ISkillServices _skillService;
        private readonly ISkillCatsServices _skillCatsServices;
        private readonly IPeopleService _peopleService;

        public SkillsController(ISkillServices skillService, ISkillCatsServices skillCatsServices, IPeopleService peopleService)
        {
            _skillService = skillService;
            _skillCatsServices = skillCatsServices;
            _peopleService = peopleService;
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
        public ActionResult Create(int skillId)
        {
            List<Members> lastMember = _peopleService.FindLast();
            List<Skills> skillList = _skillService.GetMySkill(lastMember[0].MemberId, skillId);
            if (skillList.Count==0)
            {
                skillList.Add(new Skills { SkillDesc= "No Skill Added yet!!!" });
            }
            CreateSkillsViewModel skillViewModel = new CreateSkillsViewModel();
            skillViewModel.MemberId = lastMember[0].MemberId;
            skillViewModel.SkillList = _skillCatsServices.GetAll();
            ViewBag.ListOfSkill = skillList;
            return View(skillViewModel);
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

        [HttpGet]
        public ActionResult GetSkills()
        {
            return Json(_skillCatsServices.GetAll());
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
