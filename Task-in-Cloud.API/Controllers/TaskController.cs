using Task_in_Cloud.API.Model.Interface;
using Task_in_Cloud.API.Service;

namespace Task_in_Cloud.API.Controllers
{
    public class TaskController
    {
        private TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }
    }
}
