﻿using System;
using System.Collections.Generic;
using System.Text;

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
