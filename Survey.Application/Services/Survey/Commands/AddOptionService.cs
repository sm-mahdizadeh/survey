using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IAddOptionService
    {
        int Execute(int questionId, string optionTitle, string optionDescription);
    }

    public class AddOptionService : BaseService, IAddOptionService
    {
        public AddOptionService(IDatabaseContext context) : base(context) { }

        public int Execute(int questionId, string optionTitle, string optionDescription)
        {
            Context.Options.Add(new Domain.Entities.Survey.Option
            {
               Description=optionDescription,
               QuestionId=questionId,
               Title=optionTitle,
            });
            return Context.SaveChanges();
        }
    }
}
