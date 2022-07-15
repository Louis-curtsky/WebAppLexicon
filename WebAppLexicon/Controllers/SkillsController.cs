﻿using Microsoft.AspNetCore.Http;
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
        public ActionResult Create(CreateSkillsViewModel showSkillModel, int memId)
        {
            List<Members> lastMember = _peopleService.FindLast();
            List<Skills> mySkillList = new List<Skills>();
            if (showSkillModel.MemberId == 0 && showSkillModel.SkillId==0)
            {
                mySkillList = _skillService.GetMySkill(lastMember[0].MemberId);
            }
            else
            {
                mySkillList.Add(new Skills { 
                    SkillId = showSkillModel.SkillId,
                    MemberId = showSkillModel.MemberId,
                    SkillDesc = showSkillModel.SkillDesc,
                    SkillLevel = showSkillModel.SkillLevel,
                    SkillYears = showSkillModel.SkillYears
                });
            }
            ViewBag.ListOfSkill = mySkillList;

            ViewBag.ID = showSkillModel.MemberId;
            CreateSkillsViewModel skillViewModel = new CreateSkillsViewModel();
            if (showSkillModel != null)
            {
                skillViewModel = showSkillModel;
            }

            skillViewModel.MemberId = lastMember[0].MemberId;
            skillViewModel.SkillList = _skillCatsServices.GetAll();
            
            return View(skillViewModel);
        }

        // POST: SkillsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Skills skillsViewModel, int skillId)
        {
            if(ModelState.IsValid)
            {
                int lastMemId = _peopleService.FindLast()[0].MemberId;
                skillsViewModel.MemberId = lastMemId;
                List<Skills> skillList = _skillService.GetMySkill(lastMemId);
                if (skillList.Count>0 && skillsViewModel != null)
                {
                    foreach (var item in skillList)
                    {
                        if (skillsViewModel != null && skillsViewModel.SkillId != item.SkillId
                            && skillsViewModel.MemberId != item.MemberId)
                        {
                            skillsViewModel.MemberId = lastMemId;
                            skillsViewModel.SkillId = skillId;
                            skillsViewModel.Xmembers = _peopleService.FindById(skillsViewModel.MemberId);
                            _skillService.Create(skillsViewModel);
                        } else
                        {
                            ModelState.AddModelError("System", "You added a dulplicated skills !!!");
                        }
                    }
                } else if (skillList.Count==0)
                {
                    skillsViewModel.MemberId = lastMemId;
                    skillsViewModel.SkillId = skillId;
                    skillsViewModel.Xmembers = _peopleService.FindById(skillsViewModel.MemberId);
                    _skillService.Create(skillsViewModel);
                } else
                {
                    ModelState.AddModelError("System", "There is no data in Skills input !!!");
                }


                CreateSkillsViewModel newSkillsModel = new CreateSkillsViewModel();

                newSkillsModel.MemberId = lastMemId;

                newSkillsModel.SkillList = _skillCatsServices.GetAll();
                skillList.Add(new Skills {
                    SkillId = skillsViewModel.SkillId,
                    SkillDesc = skillsViewModel.SkillDesc,
                    SkillLevel = skillsViewModel.SkillLevel,
                    SkillYears = skillsViewModel.SkillYears
                });
                ViewBag.ListOfSkill = skillList;
                return View(newSkillsModel);
            } else
            {
                ModelState.AddModelError("System", "Problem Adding Skills- Please Contact Administrator!!!");
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
