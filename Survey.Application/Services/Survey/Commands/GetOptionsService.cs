using Microsoft.EntityFrameworkCore;
using Survey.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IGetOptionsService
    {
        Dictionary<int, string> Execute(int questionId);
        Task<Dictionary<int, string>> ExecuteAsync(int questionId);
    }
    public class GetOptionsService : BaseService, IGetOptionsService
    {
        public GetOptionsService(IDatabaseContext context) : base(context) { }
        public Dictionary<int, string> Execute(int questionId)
            => Context.Options.Where(w => w.QuestionId == questionId).ToDictionary(k => k.Id, v => v.Title);

        public async Task<Dictionary<int, string>> ExecuteAsync(int questionId)
           => await Context.Options.Where(w => w.QuestionId == questionId).ToDictionaryAsync(k => k.Id, v => v.Title);
    }
}
