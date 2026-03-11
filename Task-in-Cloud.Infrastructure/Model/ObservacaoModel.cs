using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Task_in_Cloud.Infrastructure.Model
{
    [Table("observacao")]
    public class ObservacaoModel: BaseModel
    {
        [PrimaryKey("idobservacao")]
        public int IdObservacao { get; set; }

        [Column("observacao")]
        public string Descricao { get; set; }

        [Column("idTask")]
        public int IdTask { get; set; }

    }
}
