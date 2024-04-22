using LibraryManagementModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentDALLib
{
    public class BorrowingRespository : IRepository<int, Book_Borrowing>

    {
        readonly Dictionary<int, Book_Borrowing> _items;
        public BorrowingRespository()
        {
            _items = new Dictionary<int, Book_Borrowing>();
        }

        public Book_Borrowing Add(Book_Borrowing item)
        {
            if (_items.ContainsValue(item))
            {
                return null;
            }
            _items[item.Id] = item;
            return item;
        }

        public int Count()
        {
            if (_items.Count == 0) return 0;
            return _items.Keys.Max();
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


        public List<Book_Borrowing> GetAll()
        {
            if (_items.Count == 0)
                return null;
            return _items.Values.ToList();
        }

        public Book_Borrowing GetById(int id)
        {
            return _items[id] ?? null;
        }


        public Book_Borrowing Update(Book_Borrowing item)
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
