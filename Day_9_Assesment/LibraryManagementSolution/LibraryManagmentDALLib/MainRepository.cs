using LibraryManagementModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasints;

namespace LibraryManagmentDALLib
{
    public class MainRepository<T> : IRepository<int, T> where T : class
    {
        readonly Dictionary<int ,T> _items; 
        public MainRepository()
        {
            _items = new Dictionary<int , T>();
        }
        
        public T Add(T item)
        {
            if (_items.ContainsValue(item))
            {
                return null;
            }
            _items[item.id] = item;
            return item;    
        }

        public bool Delete(int key)
        {
            if (_items.ContainsKey(key))
            {
                var item = _items[key];
                _items.Remove(key);
                return true;
            }
            return false;
        }

        
        public List<T> GetAll()
        {
            if (_items.Count == 0)
                return null;
            return _items.Values.ToList();
        }

        public T GetById(int id)
        {
            return _items[id] ?? null;
        }


        public T Update(T item)
        {
            if (_items.ContainsKey(item.Id))
            {
                _items[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
