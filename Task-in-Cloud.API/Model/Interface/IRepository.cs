namespace Task_in_Cloud.API.Model.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll(); 
        Task<bool> Post(T Entity);
        Task<bool> Put(T Entity);
        Task<bool> Delete(int id);
    }
}
