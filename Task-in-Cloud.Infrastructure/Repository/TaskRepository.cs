using Supabase;
using Supabase.Postgrest.Responses;
using Task_in_Cloud.Domain.Interface;
using Task_in_Cloud.Infrastructure.Model;
using Task = Task_in_Cloud.Domain.Model.Entity.Task;

namespace Task_in_Cloud.Infrastructure.Repository
{
    public class TaskRepository: IRepository<Task>
    {
        public TaskRepository(Client client)
        {
        }

        protected readonly Client _client;

        public virtual async Task<Task> Get(int id)
        {
            ModeledResponse<TaskModel> model = await _client.From<TaskModel>()
                                                    .Filter($"id{nameof(TaskModel)}", Supabase.Postgrest.Constants.Operator.Equals, id)
                                                    .Get();

            return model.Models.FirstOrDefault();
        }

        public virtual async Task<List<Task>> GetAll()
        {
            ModeledResponse<TaskModel> model = await _client.From<TaskModel>()
                                                    .Get();

            return model.Models;
        }

        public virtual async Task<bool> Post(Task Entity)
        {
            await _client.From<TaskModel>().Insert(Entity);
            return true;
        }

        public virtual async Task<bool> Put(TaskModel Entity)
        {
            await _client.From<TaskModel>().Update(Entity);
            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            await _client.From<TaskModel>()
                         .Filter($"Id{nameof(TaskModel)}", Supabase.Postgrest.Constants.Operator.Equals, id)
                         .Delete();

            return true;
        }
    }
}
