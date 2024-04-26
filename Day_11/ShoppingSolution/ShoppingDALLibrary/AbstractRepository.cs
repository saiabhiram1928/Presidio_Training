using ShoppingDALLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository <K,T> : IRepository<K,T> where T : class
    {
        protected List<T> items = new List<T>();
        public T Add(T item)
        {
            if (items.Contains(item))
            {
                throw new DuplicateObjectException("The Item With Given Id Already Exists");
            }
            items.Add(item);
            return item;
        }
        public ICollection<T> GetAll()
        {
      
            return items.ToList<T>();
        }
       
        public abstract T Delete(K key);
        public abstract T GetByKey(K key);
        public abstract T Update(T item);
    }
}
