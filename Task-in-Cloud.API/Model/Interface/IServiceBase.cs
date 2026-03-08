namespace Task_in_Cloud.API.Model.Interface
{
    public interface IService<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> GetAll();
        Task<bool> Post(string JsonModel);
        Task<bool> Put(string JsonModel);
        Task<bool> Delete(int id);
    }
}