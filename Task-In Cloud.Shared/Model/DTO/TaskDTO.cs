using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_in_Cloud.Infrastructure.Model.Enums;

namespace Task_In_Cloud.Shared.Model.DTO
{
    public class TaskDTO
    {
        public int IdTask { get; set; }

        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Nova;

        public int? IdWorkspace { get; set; }
    }
}
