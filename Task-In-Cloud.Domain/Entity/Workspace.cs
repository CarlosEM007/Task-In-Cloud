using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Task_in_Cloud.Domain.Model.Entity
{
    [Table("workspace")]
    public class Workspace : BaseModel
    {
        [PrimaryKey("idworkspace")]
        public int IdWorkspace { get; set; }

        [Column("titulo")]
        public string Nome { get; set; }

        [Column("descricao")]
        public string? Descricao { get; set; }
    }
}
