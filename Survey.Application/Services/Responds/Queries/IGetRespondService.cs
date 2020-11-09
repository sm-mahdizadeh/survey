using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Responds.Queries
{
    public interface IGetRespondService
    {
        GetRespondDto Execute(int surveyId, int? userId, string userIp, string userInfo);
    }
}
