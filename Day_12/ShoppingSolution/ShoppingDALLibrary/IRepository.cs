﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    internal interface IRepository <K ,T> where T : class
    {
        T Add(T item);
        T GetByKey(K key);
        ICollection<T> GetAll();
        T Update(T item);
        T Delete(K key);
    }
}
