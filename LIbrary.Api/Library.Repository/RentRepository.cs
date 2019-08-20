using Library.Domain;
using Library.Infra.Repository.DbConfiguration;
using System.Data;

namespace Library.Infra.Repository
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        public RentRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }
        public RentRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }
    }
}
