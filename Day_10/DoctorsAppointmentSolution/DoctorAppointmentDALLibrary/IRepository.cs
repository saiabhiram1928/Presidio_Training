﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public interface IRepository<K,T> where T : class
    {
         List<T> GetAll();
        T GetById(K key);
        T Add(T item);
        T Update(T item);
        bool Delete(K key);

    }
}
