using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Survey.Queries;
using Survey.Web.Models;

namespace Survey.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetSurveysService _getSurveysService;
        public HomeController(IGetSurveysService getSurveysService)
        {
            _getSurveysService = getSurveysService;
        }
        public IActionResult Index()
        {
            var model=_getSurveysService.Execute(new Application.Services.Users.Queries.RequestGetUserDto { Page = 1, Searchkey = "" });
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
