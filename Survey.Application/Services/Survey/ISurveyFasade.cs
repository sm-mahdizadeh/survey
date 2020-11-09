using Survey.Application.Services.Survey.Commands;
using Survey.Application.Services.Survey.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Survey
{
    public interface ISurveyFasade
    {
        IAddSurveyService AddSurvey { get; }
        IRemoveSurveyService RemoveSurvey { get; }
        IGetSurveyService GetSurvey { get; }
        IGetSurveysService GetSurveys { get; }
        IAddQuestionService AddQuestion { get; }
        IRemoveQuestionService RemoveQuestion { get; }
        IAddOptionService AddOption { get; }
        IRemoveOptionService RemoveOption { get; }
        IGetOptionsService GetOptions { get; }
    }
}
