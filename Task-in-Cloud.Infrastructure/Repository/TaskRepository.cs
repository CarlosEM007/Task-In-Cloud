using Supabase;
using Supabase.Postgrest.Responses;
using Task_in_Cloud.Domain.Interface;
using Task_in_Cloud.Infrastructure.Model;
using Task = Task_in_Cloud.Domain.Model.Entity.Task;

namespace Task_in_Cloud.Infrastructure.Repository
{
    public class TaskRepository: IRepository<Task>
    {
        protected readonly Client _client;

        public TaskRepository() { }

        public TaskRepository(Client client)
        {
            _client = client;
        }

        public virtual async Task<Task> Get(int id)
        {
            ModeledResponse<TaskModel> model = await _client.From<TaskModel>()
                                                            .Filter($"idtask", Supabase.Postgrest.Constants.Operator.Equals, id)
                                                            .Get();

            if (model == null)
                return null;

            return Mapper.Mapper.MapperObject<Task>(model.Models.FirstOrDefault());
        }

        public virtual async Task<List<Task>> GetAll()
        {
            ModeledResponse<TaskModel> model = await _client.From<TaskModel>()
                                                    .Get();

            if (model.Models.Count == 0)
            {
                return new List<Task>();
            }

            return Mapper.Mapper.MapperListObjects<Task>(model.Models);
        }

        public virtual async Task<bool> Post(Task Entity)
        {
            TaskModel Task = Mapper.Mapper.MapperObject<TaskModel>(Entity);

            await _client.From<TaskModel>().Insert(Task);
            return true;
        }

        public virtual async Task<bool> Put(Task Entity)
        {
            TaskModel Task = Mapper.Mapper.MapperObject<TaskModel>(Entity);

            await _client.From<TaskModel>().Update(Task);
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            await _client.From<TaskModel>()
                         .Filter($"idtask", Supabase.Postgrest.Constants.Operator.Equals, id)
                         .Delete();

            return true;
        }
    }
}
