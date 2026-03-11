using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Task_in_Cloud.Infrastructure.Model
{
    [Table("workspace")]
    public class WorkspaceModel: BaseModel
    {
        [PrimaryKey("idworkspace")]
        public int IdWorkspace { get; set; }

        [Column("Titulo")]
        public string Nome { get; set; }
    }
}
