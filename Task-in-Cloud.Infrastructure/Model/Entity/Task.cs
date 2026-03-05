using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;
using Task_in_Cloud.Infrastructure.Model.Enums;

namespace Task_in_Cloud.Infrastructure.Model.Entity
{
    [Table("task")]
    public class Task: BaseModel
    {
        [PrimaryKey("idtask")]
        public int IdTask { get; set; }

        [Column("titulo")]
        public required string Titulo { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }

        [Column("status")]
        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Nova;

        [Column("idworkspace")]
        public int? IdWorkspace { get; set; }
    }
}
