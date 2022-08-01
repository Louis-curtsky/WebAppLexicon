using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAppLexicon.Models.Identity;
using WebAppLexicon.Models.Identity.ViewModels;
using WebAppLexicon.Models.Members;
using WebAppLexicon.Models.Members.Data;
using WebAppLexicon.Models.Members.Services;

namespace WebAppLexicon.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPeopleService _peopleService;

        //        private readonly MemberDbContext _memberDbContext;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
                    RoleManager<IdentityRole> roleManager, IPeopleService peopleService)// Constructor Injection
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _peopleService = peopleService;
 //           _memberDbContext = memberDbContext;
        }


        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Members = _peopleService.FindWithPending();
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userReg, int memberId)
        {
            List<Members> memberList = _peopleService.FindWithPending();
            AppUser user = new AppUser();
                foreach (var item in memberList)
                {
                    if (item.MemberId == memberId)
                    {
                        user.UserName = userReg.UserName;
                        user.NormalizedUserName = userReg.UserName;
                        user.NormalizedEmail = item.Email;
                        user.Email = item.Email;
                        user.FirstName = item.FirstName;
                        user.LastName = item.LastName;
                        user.MemberId = item.MemberId;
                        user.PhoneNumber = item.Phone;
                        user.PhoneNumberConfirmed = true;
//                        user.UserRolesId = "a3b461ee-d2e3-4e0f-8572-f50ee32d3ff5";

                    // UserRoleID string is taken from NetUser after Seeding

                    }
                };

            if (ModelState.IsValid)
            {
                IdentityResult result = await _userManager.CreateAsync(user, userReg.Password);

                if (result.Succeeded)
                {
                    Members member = _peopleService.FindById(memberId);
                    IdentityRole roleU = new IdentityRole("User");
                    IdentityResult resultU = await _userManager.AddToRoleAsync(user, roleU.Name);

                    if (resultU.Succeeded)
                    {
                        member.MemberApproval = "Approved";
                        _peopleService.Edit(member);
                        return RedirectToAction("Index", "Home");
                    }
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
            return View(userReg);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AppUser loginUser, string password)
        {

            if (ModelState.IsValid)
            {

                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginUser.UserName, password, false, false);
                if (result.Succeeded)
                {
                    AppUser showUser = await _userManager.FindByNameAsync(loginUser.UserName);
                    return RedirectToAction("Index", "Home", new {id=showUser.MemberId});
                }
                ViewBag.Msg = "Login Successful!";
            }
            else
            {
                ViewBag.Msg = "Invalid State!!!";
                //Invalid Model state. Repeat Login
                throw new ArgumentException(
                    "Problem with Login occurred! Please try again!");

            }
            return View(loginUser);


        } // End Login Post

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetMemberById(int memberId)
        {
            {
                Members regMembers = _peopleService.FindById(memberId);

                //              var lstToReturn = lstCities.Select(s => new { id = s.CityId, Name = s.CityName });
                return Json(regMembers);
            }
        }
    }
}
