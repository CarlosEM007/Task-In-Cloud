using Task_in_Cloud.Infrastructure.Model;
using Task_in_Cloud.Infrastructure.Repository;

namespace Task_in_Cloud.Domain.Service
{
    public class WorkspaceService : ServiceBase<Workspace>
    {
        public WorkspaceService(WorkspaceRepository Repository) : base(Repository)
        {
            _repository = Repository;
        }
    }
}
