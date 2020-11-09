using Survey.Application.Interfaces;
using Survey.Application.Services.Survey.Commands;
using Survey.Application.Services.Survey.Queries;

namespace Survey.Application.Services.Survey
{
    public class SurveyFasade : BaseService, ISurveyFasade
    {
        public SurveyFasade(IDatabaseContext context) : base(context) { }


        private IAddSurveyService _addSurvey;
        public IAddSurveyService AddSurvey => _addSurvey = _addSurvey ?? new AddSurveyService(Context);

        private IRemoveSurveyService _removeSurvey;
        public IRemoveSurveyService RemoveSurvey => _removeSurvey = _removeSurvey ?? new RemoveSurveyService(Context);


        private IGetSurveyService _getSurvey;
        public IGetSurveyService GetSurvey => _getSurvey = _getSurvey ?? new GetSurveyService(Context);

        private IGetSurveysService _getSurveys;
        public IGetSurveysService GetSurveys => _getSurveys = _getSurveys ?? new GetSurveysService(Context);


        private IAddQuestionService _addQuestion;
        public IAddQuestionService AddQuestion => _addQuestion = _addQuestion ?? new AddQuestionService(Context);


        private IRemoveQuestionService _removeQuestion;
        public IRemoveQuestionService RemoveQuestion => _removeQuestion = _removeQuestion ?? new RemoveQuestionService(Context);



        private IAddOptionService _addOption;
        public IAddOptionService AddOption => _addOption = _addOption ?? new AddOptionService(Context);

        private IRemoveOptionService _removeOption;
        public IRemoveOptionService RemoveOption => _removeOption = _removeOption ?? new RemoveOptionService(Context);

        private IGetOptionsService _getOptions;
        public IGetOptionsService GetOptions => _getOptions = _getOptions ?? new GetOptionsService(Context);

    }
}
