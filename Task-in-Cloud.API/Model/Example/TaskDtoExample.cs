using Swashbuckle.AspNetCore.Filters;
using Task_in_Cloud.Domain.Model.Enums;
using Task_In_Cloud.Shared.Model.DTO;

namespace Task_in_Cloud.API.Model.Example
{
    /// <summary>
    /// Exemplo de payload para criação de Task no Swagger.
    /// </summary>
    public class TaskDtoExample : IExamplesProvider<TaskDTO>
    {
        /// <summary>
        /// Retorna um exemplo de TaskDTO para documentação.
        /// </summary>
        public TaskDTO GetExamples()
        {
            return new TaskDTO
            {
                IdTask = 1,
                Titulo = "Estudar Arquitetura",
                Descricao = "Com foco em DDD",
                Status = TaskStatusEnum.Nova,
                IdWorkspace = 1
            };
        }
    }
}
