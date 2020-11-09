using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Survey;
using Survey.Web.Utility;

namespace Survey.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ISurveyFasade _surveyServives;
        public QuestionController(ISurveyFasade surveyServives)
        {
            _surveyServives = surveyServives;
        }
        [HttpPost]
        public JsonResult Create(int surveyId, string title,string description)
        {
            var result =_surveyServives.AddQuestion.Execute(User.Identity.GetId(), surveyId, title, description);
            return Json(new { IsSuccess = true, Data = result });
        }
        public JsonResult Remove(int surveyId,int questionId)
        {
            var result =_surveyServives.RemoveQuestion.Execute(surveyId,questionId);
            return Json(new { IsSuccess = true, Data = result });
        }
      
    }
}