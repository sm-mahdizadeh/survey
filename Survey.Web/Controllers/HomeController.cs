using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Survey;
using Survey.Web.Models;

namespace Survey.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISurveyFasad _surveyServices;
        public HomeController(ISurveyFasad surveyServices)
        {
            _surveyServices = surveyServices;
        }
        public IActionResult Index()
        {
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
