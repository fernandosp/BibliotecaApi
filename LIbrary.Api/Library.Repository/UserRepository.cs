using Library.Domain;
using Library.Infra.Repository.DbConfiguration;
using System.Data;

namespace Library.Infra.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }
        public UserRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }
    }
}
