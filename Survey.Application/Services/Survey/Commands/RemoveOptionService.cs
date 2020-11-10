using Survey.Application.Interfaces;
using System.Threading.Tasks;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IRemoveOptionService
    {
        bool Execute(int id);
        Task<bool> ExecuteAsync(int id);
    }
    public class RemoveOptionService : BaseService, IRemoveOptionService
    {
        public RemoveOptionService(IDatabaseContext context) : base(context) { }

        public bool Execute(int id)
        {
            var entity = Context.Options.Find(id);
            Context.Options.Remove(entity);
            return Context.SaveChanges() > 0;
        }
        public async Task< bool> ExecuteAsync(int id)
        {
            var entity = Context.Options.Find(id);
            Context.Options.Remove(entity);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}
