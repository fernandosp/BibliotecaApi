using System;
using System.Collections.Generic;

namespace Library.Infra.Repository
{
    public interface IRepository<T> : IDisposable
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> Query(string where = null);
    }
}