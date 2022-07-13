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
    public class PersonController : Controller
    {
        private readonly IPeopleService _peopleService;
        private readonly ICountryServices _countryService;
        private readonly ICityServices _cityService;
        private readonly IStateServices _stateService;

        public PersonController(IPeopleService peopleService, ICountryServices countryService,
            ICityServices cityService, IStateServices stateService)
        {
            _peopleService = peopleService;
            _countryService = countryService;
            _cityService = cityService;
            _stateService = stateService;
        }
        // GET: PersonController
        public ActionResult Index()
        {
            List<Members> listPerson = _peopleService.All();
/*            string[] forLang = new string[listPerson.Count];
            List<PersonLanguage> chkLang = new List<PersonLanguage>();
*/            for (int i = 1; i < listPerson.Count - 1; i++)
            {
                listPerson[i].Country = _countryService.FindById(listPerson[i].CntyId);
                listPerson[i].State = _stateService.FindById(listPerson[i].StateId);
                listPerson[i].City = _cityService.FindById(listPerson[i].CtyId);

//                chkLang = _peopleService.GetLanguage(listPerson[i].Id);
/*                for (int j = 0; j < chkLang.Count; j++)
                {
                    listPerson[i].languageSpoken[j].LanguageId = chkLang[j].LanguageId;
                    forLang[i] = "-";
                    forLang[i] = _languageService.GetLangName(chkLang[j].LanguageId);
                    listPerson[i].languageSpoken[j].Language.LangName = forLang[i];
                    listPerson[i].Country.Cname= _countryService.FindById(listPerson[i].CntyId).Cname;
                };*/
            }
 //           ViewBag.Language = chkLang;

            return View(listPerson);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            CreateMemberViewModel memberViewModel = new CreateMemberViewModel();
            List <Members> lastMember = _peopleService.FindLast();
            memberViewModel.MemberId = lastMember[0].MemberId+1;
            return View(memberViewModel);
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMemberViewModel memberViewModel, string memberType, string govIdType)
        {
            if (ModelState.IsValid)
            {
                if (memberViewModel != null)
                {
                    List<Members> lastMember = _peopleService.FindLast();
                    memberViewModel.MemberId = lastMember[0].MemberId + 1;
                    memberViewModel.MemberType = memberType;
                    memberViewModel.GovIdType = govIdType;
                    _peopleService.Add(memberViewModel);
                }
            }
            return View(memberViewModel);
            
        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonController/Edit/5
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

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
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
