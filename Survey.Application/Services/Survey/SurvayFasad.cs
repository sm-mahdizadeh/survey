using Survey.Application.Interfaces;
using Survey.Application.Services.Survey.Commands;
using Survey.Application.Services.Survey.Queries;
using Survey.Application.Services.Users.Commands;

namespace Survey.Application.Services.Survey
{
    public class SurveyFasad : BaseService, ISurveyFasad
    {
        public SurveyFasad(IDatabaseContext context) : base(context) { }


        private IAddSurveyService _addSurvey;
        public IAddSurveyService AddSurvey => _addSurvey = _addSurvey ?? new AddSurveyService(Context);


        private IGetSurveyService _getSurvey;
        public IGetSurveyService GetSurvey => _getSurvey = _getSurvey ?? new GetSurveyService(Context);

        private IGetSurveysService _getSurveys;
        public IGetSurveysService GetSurveys => _getSurveys = _getSurveys ?? new GetSurveysService(Context);
        
    }
}
