using Survey.Application.Interfaces;
using Survey.Application.Services.Users.Queries;
using Survey.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.Application.Services.Survey.Queries
{
    public interface IGetSurveyService
    {
        GetSurveyDto Execute(int id);
    }
    public class GetSurveyService : BaseService, IGetSurveyService
    {

        public GetSurveyService(IDatabaseContext context) : base(context) { }

        public GetSurveyDto Execute(int id)
        {
            var survey = Context.Surveys.Find(id);

            return new GetSurveyDto
            {
                Title = survey.Title,
                Description = survey.Description,
                Id = survey.Id,
                CreateDate = survey.CreateDate,
                IsActive = survey.IsActive,
                UserId = survey.UserId,
                UserFullName = Context.Users.FirstOrDefault(f => f.Id == survey.UserId).FullName,
                Questions = Context.Questions.Where(w=>w.SurveyId==id)?.Select(s => new GetQuestionsDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    Options= Context.Options.Where(w => w.QuestionId == s.Id).Select(o => new GetOptionsDto {Id =o.Id,Title=o.Title,Description=o.Description}).ToArray()
                }).ToArray()
            };
        }
    }

    public class GetSurveyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public DateTime CreateDate { get; set; }
        public GetQuestionsDto[] Questions { get; set; }
    }

    public class GetQuestionsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public GetOptionsDto[] Options { get; set; }
    }

    public class GetOptionsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
