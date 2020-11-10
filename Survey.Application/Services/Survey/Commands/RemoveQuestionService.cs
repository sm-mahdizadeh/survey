using Survey.Application.Interfaces;
using System.Threading.Tasks;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IRemoveQuestionService
    {
        bool Execute(int surveyId, int questionId);
        Task<bool> ExecuteAsync(int surveyId, int questionId);
    }
    public class RemoveQuestionService : BaseService, IRemoveQuestionService
    {
        public RemoveQuestionService(IDatabaseContext context) : base(context) { }

        public bool Execute(int surveyId, int questionId)
        {
            var entity = Context.Questions.Find(questionId);
            Context.Questions.Remove(entity);
            return Context.SaveChanges() > 0;
        }
        public async Task<bool> ExecuteAsync(int surveyId, int questionId)
        {
            var entity = Context.Questions.Find(questionId);
            Context.Questions.Remove(entity);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
