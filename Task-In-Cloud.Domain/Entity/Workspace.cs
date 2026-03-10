using System.Threading.Tasks;

namespace Task_in_Cloud.Domain.Model.Entity
{
    public class Workspace
    {
        public int IdWorkspace { get; set; }

        public string Nome { get; set; }

        public string? Descricao { get; set; }

        public Workspace() { }

        public Workspace(int idWorkspace, string nome, string? descricao)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("Nome da Workspace não pode ser Nulo!");
            }

            IdWorkspace = idWorkspace;
            Nome = nome;
            Descricao = descricao;
        }


    }
}
