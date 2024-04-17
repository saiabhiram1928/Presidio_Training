using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public interface IRepository<K,T> where T : class
    {
        List<T> GetAll();
        T GetById(K id);
        T Add (T item);
        T Update (T item);
        T Delete (K id);
    }
}
