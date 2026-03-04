using Microsoft.AspNetCore.Mvc;

namespace Task_in_Cloud.API.Model.Interface
{
    public interface IController
    {
        [HttpGet("{id}")]
        public Task<IActionResult> Get([FromRoute] int id);

        public Task<IActionResult> Post([FromRoute] string JsonModel);
        public Task<IActionResult> Delete([FromRoute] int id);
        public Task<IActionResult> Put([FromRoute] string JsonModel);
    }
}
