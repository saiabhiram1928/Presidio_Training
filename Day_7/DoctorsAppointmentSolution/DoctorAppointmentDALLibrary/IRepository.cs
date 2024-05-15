using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    internal interface IRepository<K,T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(K key);
        Task <T> Add(T item);
        bool Update(T item);
        Task<bool> Delete(K key);

    }
}
