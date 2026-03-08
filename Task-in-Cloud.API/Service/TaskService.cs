using Task_in_Cloud.Infrastructure.Model.Entity;
using Task_in_Cloud.Infrastructure.Repository;

namespace Task_in_Cloud.API.Service
{
    public class TaskService: ServiceBase<TaskModel>
    {
        public TaskService(TaskRepository Repository) : base(Repository)
        {
        }
    }
}
