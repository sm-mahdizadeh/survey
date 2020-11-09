using Survey.Application.Interfaces;

namespace Survey.Application.Services.Survey.Commands
{
    public interface IRemoveOptionService
    {
        bool Execute(int id);
    }
    public class RemoveOptionService : BaseService, IRemoveOptionService
    {
        public RemoveOptionService(IDatabaseContext context) : base(context) { }
       
       public bool Execute( int id)
        {
            var entity=Context.Options.Find(id);
            Context.Options.Remove(entity);
          return  Context.SaveChanges()>0;
        }
    }
}
