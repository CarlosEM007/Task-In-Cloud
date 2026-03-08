using Supabase;

namespace Task_in_Cloud.Infrastructure.Repository
{
    public class TaskRepository: RepositoryBase<Model.Entity.Task>
    {
        public TaskRepository(Client client): base(client)
        {
        }   
    }
}
