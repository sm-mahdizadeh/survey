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

namespace Survey.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ISurveyFasad _surveyServices;
        private readonly IRespondFasad _respondServices;

        public SurveyController(ISurveyFasad surveyServices, IGetSurveyService getSurveyService,IRespondFasad respondServices)
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
        public JsonResult Create(string title, string description)
        {
            var result = _surveyServices.AddSurvey.Exeute(1, title, description);
            return Json(new { IsSuccess = true, Data = result });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var model = _surveyServices.GetSurvey.Execute(id);
            return View(model);
        }
        public IActionResult Respond(int id)
        {
            var model = _surveyServices.GetSurvey.Execute(id);
            return View(model);
        }


        [HttpPost]
        public JsonResult Respond(int id,string answers)
        {
            var list = answers.Split(';',StringSplitOptions.RemoveEmptyEntries);
            var answerDic = new Dictionary<int, int>();
            foreach (var item in list)
            {
                answerDic.Add(int.Parse(item.Split(',')[0]), int.Parse(item.Split(',')[1]));
            }

           var result= _respondServices.AddRespond.Execute(id, 1, "", "", answerDic.Select(s=>s.Value));
            return Json(new { IsSuccess=result});
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var model = _surveyServices.GetSurvey.Execute(id);
            return View(model);
        }

    }
}