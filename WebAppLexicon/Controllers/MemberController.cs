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
    public class MemberController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICountryServices _countryService;
        private readonly ICityServices _cityService;
        private readonly IStateServices _stateService;
        private readonly ILanguageService _languageService;

        public MemberController(IPeopleService peopleService, ICountryServices countryService,
            ICityServices cityService, IStateServices stateService, ILanguageService languageService)
        {
            _peopleService = peopleService;
            _countryService = countryService;
            _cityService = cityService;
            _stateService = stateService;
            _languageService = languageService;
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
            // Testing use
            //List<State> lstStates = _stateService.BindCountry(1);
            //ViewBag.StateList = lstStates;
            //
            CreateMemberViewModel memberViewModel = new CreateMemberViewModel();
            List<Members> lastMember = _peopleService.FindLast();
            memberViewModel.MemberId = lastMember[0].MemberId + 1;
            // For testing put to True ViewBag.SaveRec = true;
            ViewBag.SaveRec = false;
            ViewBag.Countries = _countryService.GetAll();
            ViewBag.Language = _languageService.GetAll();
            return View(memberViewModel);
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMemberViewModel memberViewModel, string memberType, string govIdType,
            int cntyId, int stateId, int cityId, string nationality)
        {
            memberViewModel.MemberApproval = "Pending";
            if (ModelState.IsValid)
            {
                string uniqueFileName = _peopleService.UploadedFile(memberViewModel);
                if (memberViewModel != null)
                {
                    List<Members> lastMember = _peopleService.FindLast();
                    memberViewModel.MemberId = lastMember[0].MemberId + 1;
                    lastMember[0].ProfilePicture = uniqueFileName;

                    memberViewModel.MemberType = memberType;
                    memberViewModel.GovIdType = govIdType;
                    memberViewModel.CntyId = cntyId;
                    memberViewModel.StateId = stateId;
                    memberViewModel.CtyId = cityId;
                    memberViewModel.Nationality = nationality;
                    memberViewModel.MemberDate = DateTime.Today;
                    _peopleService.Add(memberViewModel);
                    ViewBag.SaveRec = true;
                }
            }
                    ViewBag.Countries = _countryService.GetAll();
                    ViewBag.Language = _languageService.GetAll();
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

        public ActionResult GetCityByStateId(int stateId)
        {
            {
                List<City> lstCities = _cityService.BindState(stateId);

//              var lstToReturn = lstCities.Select(s => new { id = s.CityId, Name = s.CityName });
                return Json(lstCities);
            }
        }


        public ActionResult GetStatesByCountryId(int countryId)
        {
            {
                List<State> lstStates = _stateService.BindCountry(countryId);
                //ViewBag.StateList = lstStates;

 //               var lstToReturn = lstStates.Select(s => new { id = s.Id, Name = s.Name });
                return Json(lstStates);
            }
        }

    }
}
