using Survey.Application.Interfaces;

namespace Survey.Application.Services.Survey
{
    public class SurvayFasad : BaseService, ISurveyFasad
    {
        public SurvayFasad(IDatabaseContext context) : base(context) { }
    }
}
