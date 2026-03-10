using Microsoft.AspNetCore.Mvc;
using Task_in_Cloud.Domain.Service;
using Task_In_Cloud.Shared.Model.DTO;
using Task = Task_in_Cloud.Domain.Model.Entity.Task;

namespace Task_in_Cloud.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController: BaseController<Task, TaskDTO>
    {
        public TaskController(TaskService service): base(service)
        {
        }
    }
}
