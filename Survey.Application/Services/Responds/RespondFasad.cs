using Survey.Application.Interfaces;
using Survey.Application.Services.Responds.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Responds
{
    public class RespondFasad : BaseService, IRespondFasad
    {
        public RespondFasad(IDatabaseContext context) : base(context) { }


        private IAddRespondService _addRespondService;
        public IAddRespondService AddRespond  => _addRespondService = _addRespondService ?? new AddRespondService(Context);

    }

}
