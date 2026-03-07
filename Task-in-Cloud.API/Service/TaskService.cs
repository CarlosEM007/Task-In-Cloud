using Task_in_Cloud.API.Model.Interface;
using Task = Task_in_Cloud.Infrastructure.Model.Entity.Task;

namespace Task_in_Cloud.API.Service
{
    public class TaskService: ServiceBase<Task>
    {
        protected IRepository<Task> _repository;

        public TaskService(IRepository<Task> Repository) : base(Repository)
        {
            _repository = Repository;
        }
    }
}
