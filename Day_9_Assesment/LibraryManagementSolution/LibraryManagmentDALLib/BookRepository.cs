﻿using LibraryManagementModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentDALLib
{
    public class BookRepository : IRepository<int,Book>

    {
        readonly Dictionary<int, Book> _items;
        public BookRepository()
        {
            _items = new Dictionary<int, Book>();
        }
       
        public Book Add(Book item)
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


        public List<Book> GetAll()
        {
            if (_items.Count == 0)
                return null;
            return _items.Values.ToList();
        }

        public Book GetById(int id)
        {
            return _items[id] ?? null;
        }


        public Book Update(Book item)
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
