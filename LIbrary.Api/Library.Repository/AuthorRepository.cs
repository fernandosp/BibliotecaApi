using Library.Domain;
using Library.Infra.Repository.DbConfiguration;
using System.Data;

namespace Library.Infra.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }
        public AuthorRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }
    }
}
