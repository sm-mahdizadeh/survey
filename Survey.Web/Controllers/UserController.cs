using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Users;

namespace Survey.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserFasade _userServices;
        public UserController(IUserFasade userServices)
        {
            _userServices = userServices;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
      
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task< JsonResult> Signup(string fullName,string email,string password)
        {
            var result = await _userServices.Signin.ExecuteAsync(fullName, email, password);

            return Json(new { IsSuccess = result.IsSuccess,Message=result.Message });
        }


        public IActionResult Signin(string returnUrl = "/")
        {
            ViewBag.Url = returnUrl;
            return View();
        }
        [HttpPost]
        public IActionResult Signin(string Email, string Password)
        {
            var signupResult = _userServices.Signup.Execute(Email, Password);
            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, signupResult.Data.Name),

            };
               

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(30),
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signupResult);
        }


        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}