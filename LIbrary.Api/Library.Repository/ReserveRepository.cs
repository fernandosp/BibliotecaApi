using Library.Domain;
using Library.Infra.Repository.DbConfiguration;
using System.Data;

namespace Library.Infra.Repository
{
    public class ReserveRepository : Repository<Reserve>, IReserveRepository
    {
        public ReserveRepository(IDatabaseFactory databaseOptions) : base(databaseOptions)
        {
        }

        public ReserveRepository(IDbConnection databaseConnection, IDbTransaction transaction = null) : base(databaseConnection, transaction)
        {
        }
    }
}