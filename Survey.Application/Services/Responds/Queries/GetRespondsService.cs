using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.Application.Services.Responds.Queries
{

    public interface IGetRespondsService
    {
        IEnumerable<GetRespondDto> Execute(int surveyId);
    }
    public class GetRespondsService : BaseService, IGetRespondsService
    {
        public GetRespondsService(IDatabaseContext context) : base(context) { }
        public IEnumerable<GetRespondDto> Execute(int surveyId)
        {
         return   Context.Responds.Where(w => w.SurveyId == surveyId).Select(s=>new GetRespondDto {
                CreateDate=s.CreateDate
            });
        }
    }
}
