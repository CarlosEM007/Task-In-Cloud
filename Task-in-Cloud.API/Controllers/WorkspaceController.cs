using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using Task_in_Cloud.API.Model.Example;
using Task_in_Cloud.Application.Model.DTO;
using Task_in_Cloud.Domain.Service;
using Task_In_Cloud.Shared;
using Task_In_Cloud.Shared.Model.DTO;

namespace Task_in_Cloud.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkspaceController : ControllerBase
    {
        private readonly WorkspaceService _service;

        public WorkspaceController(WorkspaceService service)
        {
            _service = service;
        }


        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                WorkspaceDTO entity = await _service.Get(id);

                if (entity == null)
                    return NotFound("Identificador inválido!");

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro durante busca: " + ex.Message);
            }
        }

        [HttpGet()]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                List<WorkspaceDTO> entity = await _service.GetAll();

                if (entity == null)
                    return NotFound("Nenhuma tarefa encontrada!");

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro durante busca: " + ex.Message);
            }
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(WorkspaceDTO), typeof(WorkspaceDtoExample))]
        public virtual async Task<IActionResult> Post([FromBody] WorkspaceDTO Workspace)
        {
            var success = false;

            try
            {
                if (Workspace != null)
                {
                    success = await _service.Post(Workspace);
                }

                if (success)
                    return Ok();

                return StatusCode(500, "Erro ao inserir dados!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir dados: " + ex.Message);
            }
        }

        [HttpPut]
        [SwaggerRequestExample(typeof(WorkspaceDTO), typeof(WorkspaceDtoExample))]
        public virtual async Task<IActionResult> Put([FromBody] WorkspaceDTO Workspace)
        {
            var success = false;

            try
            {
                if (Workspace != null)
                {
                    success = await _service.Put(Workspace);
                }

                if (success)
                    return Ok();

                return StatusCode(500, "Erro ao atualizar dados!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao atualizar dados: " + ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool success = await _service.Delete(id);

                if (success)
                    return Ok();

                return StatusCode(500, "Erro ao deletar dados!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao deletar dados: " + ex.Message);
            }
        }
    }
}
