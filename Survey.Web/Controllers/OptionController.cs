using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Survey;

namespace Survey.Web.Controllers
{
    public class OptionController : Controller
    {
        private readonly ISurveyFasade _surveyServives;
        public OptionController(ISurveyFasade surveyServives)
        {
            _surveyServives = surveyServives;

        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult List(int id)
        {
            var result = _surveyServives.GetOptions.Execute(id);
            return PartialView(result);
        }
        [HttpPost]
        public JsonResult Create(int questionId, string title, string description)
        {
            var result = _surveyServives.AddOption.Execute(questionId, title, description);
            return Json(new { IsSuccess = true, Data = result });
        }

        public JsonResult Remove( int id)
        {
            var result = _surveyServives.RemoveOption.Execute(id);
            return Json(new { IsSuccess = true, Data = result });
        }
    }
}