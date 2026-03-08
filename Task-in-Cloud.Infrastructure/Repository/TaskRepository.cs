using Supabase;
using Task_in_Cloud.Infrastructure.Model.Entity;

namespace Task_in_Cloud.Infrastructure.Repository
{
    public class TaskRepository: RepositoryBase<TaskModel>
    {
        public TaskRepository(Client client): base(client)
        {
        }   
    }
}
