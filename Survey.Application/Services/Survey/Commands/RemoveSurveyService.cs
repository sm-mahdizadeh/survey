using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IRemoveSurveyService
    {
        bool Execute(int userId, int surveyId);
        Task<bool> ExecuteAsync(int userId, int surveyId);
    }
    public class RemoveSurveyService : BaseService, IRemoveSurveyService
    {
        public RemoveSurveyService(IDatabaseContext context) : base(context) { }

        public bool Execute(int userId, int surveyId)
        {
            var entity = Context.Surveys.Find(surveyId);
            if (entity.UserId != userId)
                return false;

            Context.Surveys.Remove(entity);
            return Context.SaveChanges() > 0;
        }
        public async Task<bool> ExecuteAsync(int userId, int surveyId)
        {
            var entity = await Context.Surveys.FindAsync(surveyId);
            if (entity.UserId != userId)
                return false;

            Context.Surveys.Remove(entity);
            return (await Context.SaveChangesAsync()) > 0;
        }
    }
}
