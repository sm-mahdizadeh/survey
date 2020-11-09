using Survey.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IGetOptionsService
    {
        Dictionary<int,string> Execute(int questionId);
    }
    public class GetOptionsService : BaseService, IGetOptionsService
    {
        public GetOptionsService(IDatabaseContext context) : base(context) { }
        public Dictionary<int, string> Execute(int questionId)
            => Context.Options.Where(w => w.QuestionId == questionId).ToDictionary(k => k.Id, v => v.Title);
    }
}
