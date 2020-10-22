using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IAddSurveyService
    {
        int Exeute(int userId, string title, string description);
    }

    public class AddSurveyService :BaseService, IAddSurveyService
    {
        public AddSurveyService(IDatabaseContext context) : base(context) { }

        public int Exeute(int userId, string title, string description)
        {
            Context.Surveys.Add(new Domain.Entities.Survey.Survey
            {
                CreateDate = DateTime.Now,
                Description = description,
                IsActive = true,
                IsRemoved = false,
                Title = title,
                UserId = userId
            });
            return Context.SaveChanges();
        }
    }
}
