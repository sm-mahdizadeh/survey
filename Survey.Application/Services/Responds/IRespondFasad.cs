using Survey.Application.Services.Responds.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Responds
{
    public interface IRespondFasad
    {
         IAddRespondService AddRespond { get; }
    }
}
