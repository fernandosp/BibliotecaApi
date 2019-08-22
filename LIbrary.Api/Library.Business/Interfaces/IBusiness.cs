using System.Collections.Generic;

namespace Library.Business
{
    public interface IBusiness<T>
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> Query(string where = null);
    }
}