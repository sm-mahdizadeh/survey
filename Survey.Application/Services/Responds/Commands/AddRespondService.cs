using Survey.Application.Interfaces;
using Survey.Domain.Entities.Respond;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Services.Responds.Commands
{
    public interface IAddRespondService
    {
        bool Execute(int surveyId, int? userId, string userIp, string userInfo, IEnumerable<int> optionIds);
       Task< bool> ExecuteAsync(int surveyId, int? userId, string userIp, string userInfo, IEnumerable<int> optionIds);
    }
    public class AddRespondService : BaseService, IAddRespondService
    {
        public AddRespondService(IDatabaseContext context) : base(context) { }

        public bool Execute(int surveyId, int? userId, string userIp, string userInfo, IEnumerable<int> optionIds)
        {
            var respond = new Respond { SurveyId = surveyId, UserId = userId, UserIp = userIp, UserInfo = userInfo, CreateDate = DateTime.Now };
            Context.Responds.Add(respond);
            return Context.SaveChanges() > 0;
            //foreach (var item in optionIds)
            //{
            //    Context.Answers.Add(new Answer {
            //        RespondId=respond.Id,
            //        OptionId=item,
            //    });
            //}
            //Context.SaveChanges();
            //return true;
        }
        public async Task< bool> ExecuteAsync(int surveyId, int? userId, string userIp, string userInfo, IEnumerable<int> optionIds)
        {
            var respond = new Respond { SurveyId = surveyId, UserId = userId, UserIp = userIp, UserInfo = userInfo, CreateDate = DateTime.Now };
            Context.Responds.Add(respond);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
