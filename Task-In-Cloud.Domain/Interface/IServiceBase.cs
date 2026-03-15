namespace Task_in_Cloud.Domain.Model.Interface
{
    public interface IService<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<bool> Post(T Task);
        Task<bool> Put(T Task);
        Task<bool> Delete(int id);
    }
}