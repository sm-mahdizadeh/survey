using Survey.Application.Interfaces;
using Survey.Domain.Entities.Respond;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Responds.Commands
{
    public interface IAddRespondService
    {
        bool Execute(int surveyId, int? userId,string userIp, string userInfo, IEnumerable<int> optionIds);
    }
    public class AddRespondService : BaseService, IAddRespondService
    {
        public AddRespondService(IDatabaseContext context) : base(context) { }

        public bool Execute(int surveyId, int? userId,string userIp, string userInfo,IEnumerable<int> optionIds)
        {
            var respond = new Respond { SurveyId = surveyId, UserId = userId, UserIp = userIp, UserInfo = userInfo, CreateDate = DateTime.Now };
            Context.Responds.Add(respond);
            Context.SaveChanges();
            foreach (var item in optionIds)
            {
                Context.Answers.Add(new Answer {
                    RespondId=respond.Id,
                    OptionId=item,
                });
            }
            Context.SaveChanges();
            return true;
        }
    }
}
