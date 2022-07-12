using Microsoft.AspNetCore.Http;
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
    public class JobsController : Controller
    {
        private readonly IJobSevices _jobServices;
        private readonly ISkillServices _skillServices;

        public JobsController(IJobSevices jobServices, ISkillServices skillServices)
        {
            _jobServices = jobServices;
            _skillServices = skillServices;
        }
        // GET: JobsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: JobsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobsController/Create
        [HttpGet]
        public ActionResult Create()
        {
            CreateJobsViewModel createjob = new CreateJobsViewModel();
            List<Skills> convSkills = _skillServices.GetAll();
            ViewBag.Skills = convSkills;
            return View(createjob);
        }

        // POST: JobsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateJobsViewModel jobView, int skillId)
        {
            var fromSkills = HttpContext.Request.Form["Skills"];
            if(ModelState.IsValid)
            {
                if(jobView != null)
                {
                    jobView.SkillId = skillId;
                    _jobServices.Create(jobView);
                }
                return RedirectToAction(nameof(Index));
            } else
            {
                ModelState.AddModelError("System", "Job List has no record!!!");
                return View();
            }
 
        }

        // GET: JobsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobsController/Edit/5
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

        // GET: JobsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobsController/Delete/5
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
