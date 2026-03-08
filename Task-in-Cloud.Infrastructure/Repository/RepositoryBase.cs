using Supabase;
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Responses;
using Task_in_Cloud.Infrastructure.Model.Interface;

namespace Task_in_Cloud.Infrastructure.Repository
{
    public class RepositoryBase<T>: IRepository<T> where T : BaseModel, new()
    {
        protected readonly Client _client;

        public RepositoryBase(Client client)
        {
            _client = client;
        }

        public virtual async Task<T> Get(int id)
        {
            ModeledResponse<T> model = await _client.From<T>()
                                           .Filter($"id{nameof(T)}", Supabase.Postgrest.Constants.Operator.Equals, id)
                                           .Get();

            return model.Models.FirstOrDefault();
        }

        public virtual async Task<List<T>> GetAll()
        {
            ModeledResponse<T> model = await _client.From<T>()
                                           .Get();

            return model.Models;
        }

        public virtual async Task<bool> Post(T Entity)
        {
            await _client.From<T>().Insert(Entity);
            return true;
        }

        public virtual async Task<bool> Put(T Entity)
        {
            await _client.From<T>().Update(Entity);
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
           await _client.From<T>()
                        .Filter($"Id{nameof(T)}", Supabase.Postgrest.Constants.Operator.Equals, id)
                        .Delete();

            return true;
        }
    }
}
