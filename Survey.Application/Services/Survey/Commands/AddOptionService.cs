using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IAddOptionService
    {
        int Execute(int questionId, string optionTitle, string optionDescription);
        Task<int> ExecuteAsync(int questionId, string optionTitle, string optionDescription);
    }

    public class AddOptionService : BaseService, IAddOptionService
    {
        public AddOptionService(IDatabaseContext context) : base(context) { }

        public int Execute(int questionId, string optionTitle, string optionDescription)
        {
            var entity = new Domain.Entities.Survey.Option
            {
                Description = optionDescription,
                QuestionId = questionId,
                Title = optionTitle,
            };
            Context.Options.Add(entity);

            if (Context.SaveChanges() > 0)
                return entity.Id;
            return -1;
        }
        public async Task<int> ExecuteAsync(int questionId, string optionTitle, string optionDescription)
        {
            var entity = new Domain.Entities.Survey.Option
            {
                Description = optionDescription,
                QuestionId = questionId,
                Title = optionTitle,
            };
            Context.Options.Add(entity);
            if ((await Context.SaveChangesAsync()) > 0)
                return entity.Id;
            return -1;
        }
    }
}
