using Supabase;
using Supabase.Postgrest.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_in_Cloud.Domain.Interface;
using Task_in_Cloud.Infrastructure.Model;

namespace Task_in_Cloud.Infrastructure.Repository
{
    public class WorkspaceRepository: IRepository<Workspace>
    {
        public WorkspaceRepository(Client client)
        {
        }

        protected readonly Client _client;

        public virtual async Task<Workspace> Get(int id)
        {
            ModeledResponse<Workspace> model = await _client.From<Workspace>()
                                                    .Filter($"idworkspace", Supabase.Postgrest.Constants.Operator.Equals, id)
                                                    .Get();

            return model.Models.FirstOrDefault();
        }

        public virtual async Task<List<Workspace>> GetAll()
        {
            ModeledResponse<Workspace> model = await _client.From<Workspace>()
                                                    .Get();

            return model.Models;
        }

        public virtual async Task<bool> Post(Workspace Entity)
        {
            await _client.From<Workspace>().Insert(Entity);
            return true;
        }

        public virtual async Task<bool> Put(Workspace Entity)
        {
            await _client.From<Workspace>().Update(Entity);
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            await _client.From<Workspace>()
                         .Filter($"idworkspace", Supabase.Postgrest.Constants.Operator.Equals, id)
                         .Delete();

            return true;
        }
    }
}
