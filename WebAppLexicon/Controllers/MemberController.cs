using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
            int cntyId, int stateId, int cityId, string nationality, int id)
        {
            memberViewModel.MemberApproval = "Pending";
            if (ModelState.IsValid)
            {
                string uniqueFileName = _peopleService.UploadedFile(memberViewModel);
                if (memberViewModel != null)
                {
                    List<Members> lastMember = _peopleService.FindLast();
                    memberViewModel.MemberId = lastMember[0].MemberId + 1;
  //                  memberViewModel.ProfileImage.FileName = uniqueFileName;

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
            MemberViewModel memberViewModel = new MemberViewModel();
            Members members = _peopleService.FindById(id);
            if (members != null)
            {
                memberViewModel.MemberId = members.MemberId;
                memberViewModel.MemberType = members.MemberType;
                memberViewModel.FirstName = members.FirstName;
                memberViewModel.LastName = members.LastName;
                memberViewModel.Nationality = members.Nationality;
                memberViewModel.Age = members.Age;
                memberViewModel.Gender = members.Gender;
                memberViewModel.GovIdType = members.GovIdType;
                memberViewModel.GovId = members.GovId;
                memberViewModel.CntyId = members.CntyId;
                memberViewModel.StateId = members.StateId;
                memberViewModel.CtyId = members.CtyId;
                memberViewModel.Email = members.Email;
                memberViewModel.Phone = members.Phone;
                memberViewModel.LangId = members.LangId;
                memberViewModel.LangRead1 = members.LangRead1;
                memberViewModel.LangWrite1 = members.LangWrite1;
                memberViewModel.MemberDate = members.MemberDate;
                memberViewModel.MemberApproval = members.MemberApproval;
                FileStream stream = _peopleService.DownLoadFile(members.ProfilePicture);
                if (members.ProfilePicture == null)
                {
                    ViewBag.FileName = "Not-found-lex-project.svg";

                }
                else
                {
                    ViewBag.FileName = members.ProfilePicture;
                }

                ViewBag.SaveRec = false;
                ViewBag.Countries = _countryService.GetAll();
                ViewBag.Language = _languageService.GetAll();
                return View(memberViewModel);
            } else
            {
                ModelState.AddModelError("System", "Fail to Find Members!!!");
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, string memberType, string govIdType,
            int cntyId, int stateId, int cityId, string nationality, string customFile, MemberViewModel memberViewModel)
        {
   
            if (memberViewModel.MemberApproval == null)
                memberViewModel.MemberApproval = "Approved";

            if (ModelState.IsValid)
            {
                Members members = new Members()
                {
                    MemberId = id,
                    MemberType = memberType,
                    FirstName = memberViewModel.FirstName,
                    LastName = memberViewModel.LastName,
                    Nationality = nationality,
                    Age = memberViewModel.Age,
                    Gender = memberViewModel.Gender,
                    GovIdType = govIdType,
                    GovId = memberViewModel.GovId,
                    CntyId = cntyId,
                    StateId = stateId,
                    CtyId = cityId,
                    Email = memberViewModel.Email,
                    Phone = memberViewModel.Phone,
                    LangId = memberViewModel.LangId,
                    LangRead1 = memberViewModel.LangRead1,
                    LangWrite1 = memberViewModel.LangWrite1,
                    MemberApproval = memberViewModel.MemberApproval,
                    MemberDate = DateTime.Today,
                    ProfilePicture = customFile
                };
                if (memberViewModel.Profile == null)
                    members.ProfilePicture = HttpContext.Request.Form.Files[0].FileName;

                ViewBag.Countries = _countryService.GetAll();
                ViewBag.Language = _languageService.GetAll();

                if ( _peopleService.Edit(members))
                   return View(memberViewModel);
            }
            ModelState.AddModelError("System", "Fail to edit Members!!!");
            return RedirectToAction(nameof(Index));
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
