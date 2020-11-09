using Survey.Application.Interfaces;
using Survey.Application.Services.Responds.Commands;
using Survey.Application.Services.Responds.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Services.Responds
{
    public class RespondFasade : BaseService, IRespondFasade
    {
        public RespondFasade(IDatabaseContext context) : base(context) { }


        private IAddRespondService _addRespondService;
        public IAddRespondService AddRespond  => _addRespondService = _addRespondService ?? new AddRespondService(Context);

        private IGetRespondService _getRespondService;
        public IGetRespondService GetRespond => _getRespondService = _getRespondService ?? new GetRespondService(Context);

        private IGetRespondsService _getRespondsService;
        public IGetRespondsService GetResponds => _getRespondsService = _getRespondsService ?? new GetRespondsService(Context);
    }

}
