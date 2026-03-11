using Supabase;
using Supabase.Postgrest.Responses;
using Task_in_Cloud.Domain.Interface;
using Task_in_Cloud.Domain.Model.Entity;
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
            ModeledResponse<WorkspaceModel> model = await _client.From<WorkspaceModel>()
                                                    .Filter($"idworkspace", Supabase.Postgrest.Constants.Operator.Equals, id)
                                                    .Get();

            return Mapper.Mapper.MapperObject<Workspace>(model.Models.FirstOrDefault());
        }

        public virtual async Task<List<Workspace>> GetAll()
        {
            ModeledResponse<WorkspaceModel> model = await _client.From<WorkspaceModel>()
                                                    .Get();

            return Mapper.Mapper.MapperListObjects<Workspace>(model.Models);
        }

        public virtual async Task<bool> Post(Workspace Entity)
        {
            WorkspaceModel Workspace = Mapper.Mapper.MapperObject<WorkspaceModel>(Entity);

            await _client.From<WorkspaceModel>().Insert(Workspace);
            return true;
        }

        public virtual async Task<bool> Put(Workspace Entity)
        {
            WorkspaceModel Workspace = Mapper.Mapper.MapperObject<WorkspaceModel>(Entity);

            await _client.From<WorkspaceModel>().Update(Workspace);
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            await _client.From<WorkspaceModel>()
                         .Filter($"idworkspace", Supabase.Postgrest.Constants.Operator.Equals, id)
                         .Delete();

            return true;
        }
    }
}
