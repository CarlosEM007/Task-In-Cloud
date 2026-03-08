using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_in_Cloud.Infrastructure.Model.Interface
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
