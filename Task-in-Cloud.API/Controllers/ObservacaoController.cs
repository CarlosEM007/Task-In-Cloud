using Microsoft.AspNetCore.Mvc;
using Task_in_Cloud.Application.Model.DTO;
using Task_in_Cloud.Application.Service;
using Task_In_Cloud.Shared;
using Task_In_Cloud.Shared.Model.DTO;

namespace Task_in_Cloud.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObservacaoController: ControllerBase
    {
        private readonly ObservacaoService _service;

        public ObservacaoController(ObservacaoService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                ObservacaoDTO entity = await _service.Get(id);

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
                List<ObservacaoDTO> entity = await _service.GetAll();

                if (entity == null)
                    return NotFound("Nenhuma tarefa encontrada!");

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro durante busca: " + ex.Message);
            }
        }

        [HttpPost("{Model}")]
        public virtual async Task<IActionResult> Post(string Model)
        {
            var success = false;

            try
            {
                ObservacaoDTO? Entity = Json<ObservacaoDTO>.Deserializar(Model);

                if (Entity != null)
                {
                    success = await _service.Post(Entity);
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

        [HttpPut("{jsonModel}")]
        public virtual async Task<IActionResult> Put(string jsonModel)
        {
            var success = false;

            try
            {
                ObservacaoDTO? Entity = Json<ObservacaoDTO>.Deserializar(jsonModel);

                if (Entity != null)
                {
                    success = await _service.Put(Entity);
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
