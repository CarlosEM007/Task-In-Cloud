using Task_In_Cloud.Shared.Model.DTO;
using Task_in_Cloud.API.Service;

using TaskModel = Task_in_Cloud.Infrastructure.Model.Entity.TaskModel;

namespace Task_in_Cloud.API.Controllers
{
    public class TaskController: BaseController<TaskModel, TaskDTO>
    {
        private TaskService _taskService;

        public TaskController(TaskService service): base(service)
        {
            _taskService = service;
        }
    }
}
