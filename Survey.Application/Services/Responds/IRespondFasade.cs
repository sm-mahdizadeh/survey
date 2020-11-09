using Survey.Application.Services.Responds.Commands;
using Survey.Application.Services.Responds.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Responds
{
    public interface IRespondFasade
    {
         IAddRespondService AddRespond { get; }
         IGetRespondService GetRespond { get; }
         IGetRespondsService GetResponds { get; }
    }
}
