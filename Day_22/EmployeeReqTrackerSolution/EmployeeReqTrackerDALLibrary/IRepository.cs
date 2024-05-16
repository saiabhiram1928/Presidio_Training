using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReqTrackerDALLibrary
{
    public interface IRepository<K,T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(K key);
        Task<T> Add(T item);
        bool Update(T item);
        Task<bool> Delete(K key);


    }
}
