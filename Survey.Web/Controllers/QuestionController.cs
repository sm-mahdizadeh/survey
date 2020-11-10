using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Survey;
using Survey.Web.Utility;
using System.Threading.Tasks;

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
        public async Task<JsonResult> Create(int surveyId, string title, string description)
        {
            var result = await _surveyServives.AddQuestion.ExecuteAsync(User.Identity.GetId(), surveyId, title, description);
            return Json(new { IsSuccess = true, Data = result });
        }
        public async Task<JsonResult> Remove(int surveyId, int questionId)
        {
            var result = await _surveyServives.RemoveQuestion.ExecuteAsync(surveyId, questionId);
            return Json(new { IsSuccess = true, Data = result });
        }

    }
}