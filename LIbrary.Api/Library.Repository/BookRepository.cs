using Library.Domain;
using Library.Infra.Repository.DbConfiguration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Library.Infra.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }
        public BookRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }
    }
}
