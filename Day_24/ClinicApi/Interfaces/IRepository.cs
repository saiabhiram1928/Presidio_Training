﻿namespace ClinicApi.Interfaces
{
    public interface IRepository<K,T> where T : class
    {
        public Task<T> GetById(K key);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Add(T item);
        public Task<T> Update(T item);
        public Task<T> Delete(K key);
    }
}
