using Supabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_in_Cloud.Infrastructure.Model;

namespace Task_in_Cloud.Infrastructure.Repository
{
    public class WorkspaceRepository: RepositoryBase<Workspace>
    {
        public WorkspaceRepository(Client client) : base(client)
        {
        }
    }
}
