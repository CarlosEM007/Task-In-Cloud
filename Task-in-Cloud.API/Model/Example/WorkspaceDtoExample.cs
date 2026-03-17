using Swashbuckle.AspNetCore.Filters;
using Task_In_Cloud.Shared.Model.DTO;

namespace Task_in_Cloud.API.Model.Example
{
    /// <summary>
    /// Exemplo de payload para criação de Workspace no Swagger.
    /// </summary>
    public class WorkspaceDtoExample : IExamplesProvider<WorkspaceDTO>
    {
        /// <summary>
        /// Retorna um exemplo de WorkspaceDTO para documentação.
        /// </summary>
        public WorkspaceDTO GetExamples()
        {
            return new WorkspaceDTO
            {
                IdWorkspace = 1,
                Titulo = "Arquitetura de sistemas",
                Descricao = "Tarefas focadas em arquitetura"
            };
        }
    }
}
