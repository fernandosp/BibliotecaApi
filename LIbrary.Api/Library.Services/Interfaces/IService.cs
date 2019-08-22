using System.Collections.Generic;

namespace Library.Services.Interfaces
{
    public interface IService<T>
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> Query(string where = null);
    }
}