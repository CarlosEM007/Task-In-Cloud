using Microsoft.AspNetCore.Mvc;
using Task_in_Cloud.Domain.Service;
using Task_In_Cloud.Shared.Model.DTO;
using Task = Task_in_Cloud.Domain.Model.Entity.Task;

namespace Task_in_Cloud.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController: ControllerBase
    {
        private readonly TaskService _service;

        public TaskController(TaskService service)
        {
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                TaskDTO entity = await _service.Get(id);

                if (entity == null)
                    return NotFound("Identificador inválido!");

                return Ok(Mapper.Map<TDTO>(entity));
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
                var entity = await _service.GetAll();

                if (entity == null)
                    return NotFound("Identificador inválido!");

                return Ok(Mapper.Map<TDTO>(entity));
            }
            catch (Exception ex)
            {
                return BadRequest("Erro durante busca: " + ex.Message);
            }
        }

        [HttpPost("{jsonModel}")]
        public virtual async Task<IActionResult> Post(string jsonModel)
        {
            try
            {
                var success = await _service.Post(jsonModel);

                if (success)
                    return Ok();

                return StatusCode(500, "Erro ao inserir dados!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao inserir dados: " + ex.Message);
            }
        }

        [HttpPut("{jsonModel}")]
        public virtual async Task<IActionResult> Put(string jsonModel)
        {
            try
            {
                var success = await _service.Put(jsonModel);

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
                var success = await _service.Delete(id);

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
