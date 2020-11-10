using Survey.Application.Interfaces;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var survey = Context.Surveys.Include(a=>a.User).Include(b=>b.Questions).ThenInclude(b=>b.Options).FirstOrDefault(f=>f.Id==id);

            return new GetSurveyDto
            {
                Title = survey.Title,
                Description = survey.Description,
                Id = survey.Id,
                CreateDate = survey.CreateDate,
                IsActive = survey.IsActive,
                UserId = survey.UserId,
                UserFullName =survey.User.FullName,
                Questions = survey.Questions.Where(w=>w.SurveyId==id)?.Select(s => new GetQuestionsDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    Options= s.Options.Select(o => new GetOptionsDto {Id =o.Id,Title=o.Title,Description=o.Description}).ToArray()
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
