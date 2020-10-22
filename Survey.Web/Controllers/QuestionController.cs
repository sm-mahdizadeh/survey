using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Services.Survey.Commands;

namespace Survey.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IAddQuestionService _addQuestionService;
        private readonly IRemoveQuestionService _removeQuestionService;
        public QuestionController(IAddQuestionService addQuestionService,IRemoveQuestionService removeQuestionService)
        {
            _addQuestionService = addQuestionService;
            _removeQuestionService = removeQuestionService;
        }
        [HttpPost]
        public JsonResult Create(int surveyId, string title,string description)
        {
            var result = _addQuestionService.Execute(1, surveyId, title, description);
            return Json(new { IsSuccess = true, Data = result });
        }
        public JsonResult Remove(int surveyId,int questionId)
        {
            var result = _removeQuestionService.Execute(surveyId,questionId);
            return Json(new { IsSuccess = true, Data = result });
        }
    }
}