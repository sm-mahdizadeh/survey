using Survey.Application.Interfaces;
using System.Threading.Tasks;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IAddQuestionService
    {
        int Execute(int userId, int surveyId, string title, string description);
        Task<int> ExecuteAsync(int userId, int surveyId, string title, string description);
    }

    public class AddQuestionService : BaseService, IAddQuestionService
    {
        public AddQuestionService(IDatabaseContext context) : base(context) { }

        public int Execute(int userId, int surveyId, string title, string description)
        {
            var entity = new Domain.Entities.Survey.Question
            {
                Description = description,
                SurveyId = surveyId,
                Title = title,
            };
            Context.Questions.Add(entity);
            if (Context.SaveChanges() > 0)
                return entity.Id;

            return -1;
        }

        public async Task<int> ExecuteAsync(int userId, int surveyId, string title, string description)
        {
            var entity = new Domain.Entities.Survey.Question
            {
                Description = description,
                SurveyId = surveyId,
                Title = title,
            };
            Context.Questions.Add(entity);
            if (await Context.SaveChangesAsync() > 0)
                return entity.Id;

            return -1;
        }
    }
}
