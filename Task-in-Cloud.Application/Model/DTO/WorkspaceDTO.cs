using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_In_Cloud.Shared.Model.DTO
{
    public class WorkspaceDTO
    {
        public int IdWorkspace { get; set; }

        public string Titulo { get; set; }

        public string? Descricao { get; set; }
    }
}
