using Microsoft.AspNetCore.Mvc;
using Task_in_Cloud.Domain.Model.Entity;
using Task_in_Cloud.Domain.Service;
using Task_in_Cloud.Infrastructure.Model;
using Task_In_Cloud.Shared.Model.DTO;

namespace Task_in_Cloud.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkspaceController : BaseController<Workspace, WorkspaceDTO> 
    {
        public WorkspaceController(WorkspaceService service) : base(service) { }
    }
}
