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
        public async Task< ActionResult> List(int id)
        {
            var result =await _surveyServives.GetOptions.ExecuteAsync(id);
            return PartialView(result);
        }
        [HttpPost]
        public async Task<JsonResult> Create(int questionId, string title, string description)
        {
            var result = await _surveyServives.AddOption.ExecuteAsync(questionId, title, description);
            return Json(new { IsSuccess = true, Data = result });
        }

        public async Task<JsonResult> Remove(int id)
        {
            var result = await _surveyServives.RemoveOption.ExecuteAsync(id);
            return Json(new { IsSuccess = true, Data = result });
        }
    }
}