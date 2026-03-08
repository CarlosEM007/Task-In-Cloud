using Microsoft.AspNetCore.Mvc;
using Supabase.Postgrest.Models;
using Task_in_Cloud.API.Service;
using Task_In_Cloud.Shared.Utils;

namespace Task_in_Cloud.API.Controllers
{
    [ApiController]
    public abstract class BaseController<TEntity, TDTO>: ControllerBase
        where TEntity : BaseModel, new()
        where TDTO : class, new()
    {
        protected readonly ServiceBase<TEntity> _service;

        protected BaseController(ServiceBase<TEntity> Service)
        {
            _service = Service;
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                var entity = await _service.Get(id);

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
