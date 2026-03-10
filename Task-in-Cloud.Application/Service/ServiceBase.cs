using Supabase.Postgrest.Models;
using Task_in_Cloud.Domain.Model.Interface;
using Task_in_Cloud.Domain.Interface;
using Task_In_Cloud.Shared.Utils;
using Task_in_Cloud.Infrastructure.Repository;

namespace Task_in_Cloud.Domain.Service
{
    public class ServiceBase<T> : IService<T> where T : class, new()
    {
        protected IRepository<T> _repository;
         
        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public virtual async Task<T> Get(int id)
        {
            return await _repository.Get(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<bool> Post(string JsonModel)
        {
            T? Entity = Json<T>.Deserializar(JsonModel);

            if (Entity == null)
            {
                return false;
            }

            return await _repository.Post(Entity);
        }

        public virtual async Task<bool> Put(string JsonModel)
        {
            T? Entity = Json<T>.Deserializar(JsonModel);

            if (Entity == null)
            {
                return false;
            }

            return await _repository.Put(Entity);
        }
    }
}
