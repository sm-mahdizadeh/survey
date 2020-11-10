using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Responds;
using Survey.Application.Services.Survey;
using Survey.Application.Services.Survey.Commands;
using Survey.Application.Services.Survey.Queries;
using Survey.Web.Utility;
using Survey.Web.Utility.Extensions;

namespace Survey.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyFasade _surveyServices;
        private readonly IRespondFasade _respondServices;

        public SurveyController(ISurveyFasade surveyServices, IRespondFasade respondServices)
        {
            _surveyServices = surveyServices;
            _respondServices = respondServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> Create(string title, string description)
        {
            var result = await _surveyServices.AddSurvey.ExeuteAsync(User.Identity.GetId(), title, description);
            return Json(new { IsSuccess = true, Data = result });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var model = _surveyServices.GetSurvey.Execute(id);
            return View(model);
        }

        [Authorize]
        public async Task<JsonResult> Remove(int id)
        {
            var result = await _surveyServices.RemoveSurvey.ExecuteAsync(User.Identity.GetId(), id);
            return Json(new { IsSuccess = result });
        }

        public IActionResult Respond(int id)
        {
            var cookies = new CookiesUtility();
            var browserId = cookies.GetBrowserId(HttpContext);
            var respond = _respondServices.GetRespond.Execute(id, User.Identity.GetId(), HttpContext.Connection.RemoteIpAddress.ToString(), HttpContext.UserInfo());
            var model = _surveyServices.GetSurvey.Execute(id);
            if (respond != null)
            {
                ViewBag.Respond = respond;
                return View("Respond_Responded", model);
            }

            return View(model);
        }


        [HttpPost]
        public async Task<JsonResult> Respond(int id, string answers)
        {

            var list = answers.Split(';', StringSplitOptions.RemoveEmptyEntries);
            var answerDic = new Dictionary<int, int>();
            foreach (var item in list)
            {
                answerDic.Add(int.Parse(item.Split(',')[0]), int.Parse(item.Split(',')[1]));
            }

            var result = await _respondServices.AddRespond.ExecuteAsync(id, User.Identity.GetId(), HttpContext.Connection.RemoteIpAddress.ToString(), HttpContext.UserInfo(), answerDic.Select(s => s.Value));
            return Json(new { IsSuccess = result });
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var model = _surveyServices.GetSurvey.Execute(id);
            return View(model);
        }

    }
}