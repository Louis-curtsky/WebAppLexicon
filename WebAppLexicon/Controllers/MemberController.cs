using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members;
using WebAppLexicon.Models.Members.Services;
using WebAppLexicon.Models.Members.ViewModel;

namespace WebAppLexicon.Controllers
{
    public class MemberController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICountryServices _countryService;
        private readonly ICityServices _cityService;
        private readonly IStateServices _stateService;
        public MemberController(IPeopleService peopleService, ICountryServices countryService,
            ICityServices cityService, IStateServices stateService)
        {
            _peopleService = peopleService;
            _countryService = countryService;
            _cityService = cityService;
            _stateService = stateService;
        }
        // GET: MemberController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            CreateMemberViewModel memberViewModel = new CreateMemberViewModel();
            List<Members> lastMember = _peopleService.FindLast();
            memberViewModel.MemberId = lastMember[0].MemberId + 1;
            ViewBag.SaveRec = true;
            //       will be remove after test on skills create    ViewBag.SaveRec = false;
            return View(memberViewModel);
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMemberViewModel memberViewModel, string memberType, string govIdType, int ctyId)
        {
            if (ModelState.IsValid)
            {
                if (memberViewModel != null)
                {
                    List<Members> lastMember = _peopleService.FindLast();
                    memberViewModel.MemberId = lastMember[0].MemberId + 1;
                    memberViewModel.MemberType = memberType;
                    memberViewModel.GovIdType = govIdType;
                    memberViewModel.CtyId = ctyId;
                    _peopleService.Add(memberViewModel);
                    ViewBag.SaveRec = true;
                }
            }
            return View(memberViewModel);
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberController/Edit/5
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

        // GET: MemberController/Delete/5

    }
}
