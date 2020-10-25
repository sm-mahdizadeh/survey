using Survey.Application.Services.Survey.Commands;
using Survey.Application.Services.Survey.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Survey
{
    public interface ISurveyFasad
    {
        IAddSurveyService AddSurvey { get; }
        IGetSurveyService GetSurvey { get; }
        IGetSurveysService GetSurveys { get; }
    }
}
