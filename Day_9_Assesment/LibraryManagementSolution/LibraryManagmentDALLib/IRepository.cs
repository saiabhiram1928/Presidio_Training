using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentDALLib
{
    internal interface IRepository<K , T> where T : class
    {
        List<T> GetAll();
        T GetById(K id);
        T Add(T item);
        T Update(T item);
        bool Delete(K id);

    }
}
