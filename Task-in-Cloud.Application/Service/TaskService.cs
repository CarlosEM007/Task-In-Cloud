using Task = Task_in_Cloud.Domain.Model.Entity.Task;
using Task_in_Cloud.Infrastructure.Repository;
using Task_in_Cloud.Domain.Model.Interface;
using Task_In_Cloud.Shared.Model.DTO;
using Task_In_Cloud.Shared.Utils;

namespace Task_in_Cloud.Application.Service
{
    public class TaskService: IService<TaskDTO>
    {
        protected TaskRepository _repository;

        public TaskService(TaskRepository Repository)
        {
            _repository = Repository;
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<TaskDTO> Get(int id)
        {
            Task Entity = await _repository.Get(id);

            return Mapper.Map<TaskDTO>(Entity);
        }

        public virtual async Task<List<TaskDTO>> GetAll()
        {
            List<Task> Entitys = await _repository.GetAll();

            return Mapper.Map<List<TaskDTO>>(Entitys);
        }

        public virtual async Task<bool> Post(TaskDTO Task)
        {
            try
            {
                Task Entity = new Task(
                    Task.IdTask,
                    Task.Titulo,
                    Task.Descricao,
                    Task.Status,
                    Task.IdWorkspace
                );

                return await _repository.Post(Entity);
            } 
            catch
            {
                return false;
            }
        }

        public virtual async Task<bool> Put(TaskDTO Task)
        {
            try
            {
                Task Entity = new Task(
                    Task.IdTask,
                    Task.Titulo,
                    Task.Descricao,
                    Task.Status,
                    Task.IdWorkspace
                );

                return await _repository.Put(Entity);
            }
            catch
            {
                return false;
            }
        }
    }
}
