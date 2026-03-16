using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_in_Cloud.Application.Model.DTO
{
    public class ObservacaoDTO
    {
        public int IdObservacao { get; set; }
        public string Descricao { get; set; }
        public int IdTask { get; set; }
    }
}
