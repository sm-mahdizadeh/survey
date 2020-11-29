using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survey.Application.Services.Survey;
using Survey.Web.Models;

namespace Survey.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISurveyFasade _surveyServices;
        public HomeController(ISurveyFasade surveyServices, ILogger<HomeController> logger)
        {
            _surveyServices = surveyServices;
            _logger = logger;
        }
        public IActionResult Index()
        {
            //_logger.Log(LogLevel.Information, "Hello");
            var model=_surveyServices.GetSurveys.Execute(new Application.Services.Users.Queries.RequestGetUsersDto { Page = 1, Searchkey = "" });
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
