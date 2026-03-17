using Task_in_Cloud.Domain.Model.Enums;

namespace Task_In_Cloud.Shared.Model.DTO
{
    public class TaskDTO
    {
        public int IdTask { get; set; } = 1;

        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Nova;

        public int? IdWorkspace { get; set; }
    }
}
