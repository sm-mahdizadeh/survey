using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Users;

namespace Survey.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserFasad _userServices;
        public UserController(IUserFasad userServices)
        {
            _userServices = userServices;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Signin()
        {
            return View();
        }
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Signup(string fullName,string email,string password)
        {
            var result = _userServices.Signin.Execute(fullName, email, password);

            return Json(new { IsSuccess = result });
        }
    }
}