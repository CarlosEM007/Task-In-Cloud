using Task_in_Cloud.Domain.Model.Enums;

namespace Task_in_Cloud.Domain.Model.Entity
{
    public class Task
    {
        public int IdTask { get; set; }

        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Nova;

        public int? IdWorkspace { get; set; }

        public Task() { }

        public Task(int idTask, string titulo, string? descricao, TaskStatusEnum status, int? idWorkspace)
        {
            if (string.IsNullOrEmpty(titulo))
            {
                throw new Exception("O título da Task deve ser preenchido!");
            }

            IdTask = idTask;
            Titulo = titulo;
            Descricao = descricao;
            Status = status;
            IdWorkspace = idWorkspace;
        }

    }
}
