using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Responds;
using Survey.Application.Services.Survey.Commands;
using Survey.Application.Services.Survey.Queries;

namespace Survey.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IAddSurveyService _addSurveyService;
        private readonly IGetSurveyService _getSurveyService;
        private readonly IRespondFasad _respondServices;
        public SurveyController(IAddSurveyService addSurveyService, IGetSurveyService getSurveyService,IRespondFasad respondServices)
        {
            _addSurveyService = addSurveyService;
            _getSurveyService = getSurveyService;

            _respondServices = respondServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(string title, string description)
        {
            var result = _addSurveyService.Exeute(1, title, description);
            return Json(new { IsSuccess = true, Data = result });
        }
        public IActionResult Edit(int id)
        {
            var model = _getSurveyService.Execute(id);
            return View(model);
        }
        public IActionResult Respond(int id)
        {
            var model = _getSurveyService.Execute(id);
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

        public IActionResult Details(int id)
        {
            var model = _getSurveyService.Execute(id);
            return View(model);
        }

    }
}