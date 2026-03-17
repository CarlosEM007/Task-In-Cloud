using Swashbuckle.AspNetCore.Filters;
using Task_in_Cloud.Application.Model.DTO;

namespace Task_in_Cloud.API.Model.Example
{
    /// <summary>
    /// Exemplo de payload para criação de Observação no Swagger.
    /// </summary>
    public class ObservacaoDtoExample : IExamplesProvider<ObservacaoDTO>
    {
        /// <summary>
        /// Retorna um exemplo de ObservacaoDTO para documentação.
        /// </summary>
        public ObservacaoDTO GetExamples()
        {
            return new ObservacaoDTO
            {
                IdObservacao = 1,
                Descricao = "Acompanhar os módulos disponíveis",
                IdTask = 1
            };
        }
    }
}
