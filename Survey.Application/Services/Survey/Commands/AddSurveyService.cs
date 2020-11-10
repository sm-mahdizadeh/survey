using Survey.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IAddSurveyService
    {
        int Exeute(int userId, string title, string description);
        Task<int> ExeuteAsync(int userId, string title, string description);
    }

    public class AddSurveyService : BaseService, IAddSurveyService
    {
        public AddSurveyService(IDatabaseContext context) : base(context) { }

        public int Exeute(int userId, string title, string description)
        {
            var entity = new Domain.Entities.Survey.Survey
            {
                CreateDate = DateTime.Now,
                Description = description,
                IsActive = true,
                IsRemoved = false,
                Title = title,
                UserId = userId
            };
            Context.Surveys.Add(entity);
            if (Context.SaveChanges() > 0)
                return entity.Id;
            return -1;
        }
        public async Task<int> ExeuteAsync(int userId, string title, string description)
        {
            var entity = new Domain.Entities.Survey.Survey
            {
                CreateDate = DateTime.Now,
                Description = description,
                IsActive = true,
                IsRemoved = false,
                Title = title,
                UserId = userId
            };
            Context.Surveys.Add(entity);
            if (await Context.SaveChangesAsync() > 0)
                return entity.Id;
            return -1;
        }
    }
}
