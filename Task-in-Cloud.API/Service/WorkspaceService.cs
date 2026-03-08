using Task_in_Cloud.API.Model.Interface;
using Task_in_Cloud.Infrastructure.Model.Entity;

namespace Task_in_Cloud.API.Service
{
    public class WorkspaceService : ServiceBase<Workspace>
    {
        public WorkspaceService(IRepository<Workspace> Repository) : base(Repository)
        {
            _repository = Repository;
        }
    }
}
