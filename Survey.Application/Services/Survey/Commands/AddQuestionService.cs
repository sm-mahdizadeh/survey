using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IAddQuestionService
    {
        int Execute(int userId, int surveyId, string title, string description);
    }

    public class AddQuestionService : BaseService, IAddQuestionService
    {
        public AddQuestionService(IDatabaseContext context) : base(context) { }

        public int Execute(int userId,int surveyId ,string title, string description)
        {
            Context.Questions.Add(new Domain.Entities.Survey.Question
            {
               Description=description,
               SurveyId=surveyId,
               Title=title,
            });
            return Context.SaveChanges();
        }
    }
}
