using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;
using Task_in_Cloud.API.Model.Example;
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

                if (entity.Count == 0)
                    return NotFound("Nenhuma tarefa encontrada!");

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro durante busca: " + ex.Message);
            }
        }

        [HttpPost("{Observacao}")]
        [SwaggerRequestExample(typeof(ObservacaoDTO), typeof(ObservacaoDtoExample))]
        public virtual async Task<IActionResult> Post(ObservacaoDTO Observacao)
        {
            var success = false;

            try
            {
                if (Observacao != null)
                {
                    success = await _service.Post(Observacao);
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

        [HttpPut("{Observacao}")]
        [SwaggerRequestExample(typeof(ObservacaoDTO), typeof(ObservacaoDtoExample))]
        public virtual async Task<IActionResult> Put(ObservacaoDTO Observacao)
        {
            var success = false;

            try
            {
                if (Observacao != null)
                {
                    success = await _service.Put(Observacao);
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
