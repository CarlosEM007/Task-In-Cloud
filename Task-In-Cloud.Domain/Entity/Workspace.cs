using System.Threading.Tasks;

namespace Task_in_Cloud.Domain.Model.Entity
{
    public class Workspace
    {
        public int IdWorkspace { get; set; }

        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public Workspace() { }

        public Workspace(int idWorkspace, string titulo, string? descricao)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                throw new Exception("Titulo da Workspace não pode ser Nulo!");
            }

            IdWorkspace = idWorkspace;
            Titulo = titulo;
            Descricao = descricao;
        }


    }
}
