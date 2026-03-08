using Task_in_Cloud.Infrastructure.Model.Entity;
using Task_in_Cloud.Infrastructure.Repository;

namespace Task_in_Cloud.Domain.Service
{
    public class TaskService: ServiceBase<Infrastructure.Model.Entity.Task>
    {
        public TaskService(TaskRepository Repository) : base(Repository)
        {
        }
    }
}
