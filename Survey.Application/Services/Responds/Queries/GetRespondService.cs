using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.Application.Services.Responds.Queries
{
    public class GetRespondService : BaseService, IGetRespondService
    {
        public GetRespondService(IDatabaseContext context) : base(context) { }
        public GetRespondDto Execute(int surveyId, int? userId, string userIp, string userInfo)
        {

            var respond = Context.Responds.FirstOrDefault(f => f.SurveyId == surveyId &&((userId>0 && f.UserId == userId)||(userId!=null &&  f.UserInfo == userInfo)  ));
            if (respond == null)
                return null;
            return new GetRespondDto { Id = respond.Id, CreateDate = respond.CreateDate };
        }
    }
}
