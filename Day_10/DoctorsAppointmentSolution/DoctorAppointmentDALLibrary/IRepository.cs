using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    internal interface IRepository<K,T> where T : class
    {
         List<T> GetAll();
        T GetById(K key);
        T Add(T item);
        T Update(T item);
        T Delete(K key);

    }
}
